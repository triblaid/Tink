namespace Project.Application;

public partial class TinkoffDebitCardCommandHandler : ICommandHandler<UpdateDebitCardRequestStatus>
{
    public async Task Handle(CommandArgs<UpdateDebitCardRequestStatus> args)
    {
        var (debitCardId, status, bankDetailsId) = args.Payload;

        var debitCard = await _debitCardRepository.GetById(debitCardId);

        if (status != DebitCardRegistrationStatus.Pending)
        {
            if (status == DebitCardRegistrationStatus.Ready)
                debitCard.UpdateBankDetailsId(bankDetailsId.Value);

            debitCard.UpdateTinkoffCardStatus(status);

            var debitCardStatus = debitCard.Status switch
            {
                DebitCardRegistrationStatus.Ready => DebitCardStatus.RegistrationSucceeded,
                DebitCardRegistrationStatus.Failed => DebitCardStatus.RegistrationFailed,
                _ => throw new NotImplementedException(),
            };
            _messages.Add(new UpdateDebitCardStatus(debitCard.DebitCardId, debitCardStatus));
        }
    }
}