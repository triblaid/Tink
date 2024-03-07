namespace Project.Application;

public partial class TinkoffDebitCardCommandHandler : ICommandHandler<DeleteDebitCard>
{
    public async Task Handle(CommandArgs<DeleteDebitCard> args)
    {
        var debitCard = await _debitCardRepository.GetById(args.Payload.DebitCardId);
        await _tinkoffService.DeleteDebitCardRequest(debitCard.BeneficiaryId, debitCard.BankDetailsId);
        debitCard.Delete();
    }
}