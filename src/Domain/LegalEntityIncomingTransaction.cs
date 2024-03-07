namespace Project;

public record LegalEntityIncomingTransaction
{
    public Guid TransactionId { get; set; }
    public Guid LegalEntityId { get; set; }
    public decimal Amount { get; set; }

    private LegalEntityIncomingTransaction() { }

    public LegalEntityIncomingTransaction(Guid transactionId, Guid legalEntityId, decimal amount)
    {
        if (transactionId == Guid.Empty) throw new BehaviourException("transactionId can't be empty uuid");
        if (legalEntityId == Guid.Empty) throw new BehaviourException("legalEntityId can't be empty uuid");
        if (amount <= 0) throw new BehaviourException("amount can't be less than 0");

        TransactionId = transactionId;
        LegalEntityId = legalEntityId;
        Amount = amount;
    }
}