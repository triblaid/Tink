namespace Project.Application;

public partial class JobPaymentCommandHandler : ICommandHandler<MakeJobPayment>
{
    public async Task Handle(CommandArgs<MakeJobPayment> args)
    {
        var payload = args.Payload;
        var workerBeneficiary = await _workerBeneficiaryRepository.GetByWorkerId(payload.WorkerId);
        var legalEntityBeneficiary = await _legalEntityBeneficiaryRepository.GetByLegalEntityId(payload.LegalEntityId);

        var completedDeal = await _tinkoffService.CreateAndCompleteDeal(payload.JobPaymentId,
            payload.Amount,
            legalEntityBeneficiary.BeneficiaryId,
            workerBeneficiary.BeneficiaryId,
            payload.JobApplicationId);

        if (!completedDeal.IsSuccess)
        {
            var declineJobPayment = new DeclineJobPayment(payload.JobPaymentId, completedDeal.Error);
            _messages.Add(declineJobPayment);
            return;
        }

        var deal = new Deal(payload.JobPaymentId, payload.Amount, completedDeal, legalEntityBeneficiary, workerBeneficiary);
        _dealRepository.Add(deal);

        _messages.Add(new CompleteJobPayment(payload.JobPaymentId));
    }
}