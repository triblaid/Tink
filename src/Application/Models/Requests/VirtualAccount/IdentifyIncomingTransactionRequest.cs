namespace Project.Application;

public record IdentifyIncomingTransactionRequest
{
    public IdentifyIncomingTransactionRequest(Guid transactionId,  Guid legalEntityBeneficiaryId, decimal amount)
    {
        OperationId = transactionId;
        AmountDistribution = new List<AmountDistribution> { new AmountDistribution { BeneficiaryId = legalEntityBeneficiaryId, Amount = amount } };
    }

    public Guid OperationId { get; init; }
    public List<AmountDistribution> AmountDistribution { get; init; }
}

public record AmountDistribution
{
    public Guid BeneficiaryId { get; init; }
    public decimal Amount { get; init; }
}