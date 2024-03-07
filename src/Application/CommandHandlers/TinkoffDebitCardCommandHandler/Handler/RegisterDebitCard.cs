namespace Project.Application;

public partial class TinkoffDebitCardCommandHandler : ICommandHandler<RegisterDebitCard, string>
{
    public async Task<string> Handle(CommandArgs<RegisterDebitCard> args)
    {
        var (workerId, debitCardId) = args.Payload;

        var debitCardRegistration = await _debitCardRepository.FindById(debitCardId);

        if (debitCardRegistration != null && debitCardRegistration.Status != DebitCardRegistrationStatus.Failed)
            throw new InvalidOperationException($"RegistrationUrl can't be changed for active debit card with debitCardId = {debitCardId}");

        var workerBeneficiary = await _workerBeneficiaryRepository.GetByWorkerId(workerId);

        var request = await _tinkoffService.CreateDebitCardRequest(workerBeneficiary.BeneficiaryId, args.CommandId);

        if (debitCardRegistration != null)
        {
            debitCardRegistration.UpdateRegistration(request.AddCardUrl, request.Status);
            _messages.Add(new UpdateDebitCardStatus(debitCardId, DebitCardStatus.RegistrationRequested));
        }
        else
        {
            var debitCard = new DebitCardRegistration(
                debitCardId,
                request.AddCardRequestId,
                workerBeneficiary.BeneficiaryId,
                request.AddCardUrl);

            _debitCardRepository.Add(debitCard);
        }

        return request.AddCardUrl;
    }
}