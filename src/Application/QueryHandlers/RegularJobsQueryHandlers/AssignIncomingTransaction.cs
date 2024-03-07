namespace Project.Application;

public partial class TinkoffQueryHandler : ICommandHandler<AssignIncomingTransaction>
{
    public async Task Handle(CommandArgs<AssignIncomingTransaction> args)
    {
        var (transactionId, tin, amount) = args.Payload;
        var transaction = await _incomingTransactionsRepository.FindById(transactionId);
        if (transaction is not null) throw new AlreadyExistsException($"Incoming transaction with id = {transactionId} is already assigned.");

        var legalEntityBeneficiary = await _legalEntityBeneficiaryRepository.FindByTin(tin);
        if (legalEntityBeneficiary is null)
        {
            _logger.LogWarning("Legal entity beneficiary with tin = {tin} was not found.", tin);
            throw new NotFoundException($"Legal entity beneficiary with tin = {tin} was not found.");
        }

        await _tinkoffService.IdentifyIncomingTransaction(transactionId, legalEntityBeneficiary.BeneficiaryId, amount);

        transaction = new LegalEntityIncomingTransaction(transactionId, legalEntityBeneficiary.LegalEntityId, amount);
        _incomingTransactionsRepository.Add(transaction);

        var placeDepositTask = new PlaceLegalEntityDeposit(legalEntityBeneficiary.LegalEntityId, transaction.Amount);
        _messages.Add(placeDepositTask);
    }
}