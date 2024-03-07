namespace Project.Application;

public record GetIncomingTransactionsResult : TinkoffRequestResult
{
    public int Size { get; init; }
    public int Total { get; init; }
    public List<IncomingTransactionResult> Results { get; init; }
}

public record IncomingTransactionResult
{
    public Guid OperationId { get; init; }
    public string AccountNumber { get; init; }
    public decimal Amount { get; init; }
    public string Currency { get; init; }
    public decimal OperationAmount { get; init; }
    public string OperationCurrency { get; init; }
    public string PayerBik { get; init; }
    public string PayerKpp { get; init; }
    public string PayerInn { get; init; }
    public string PayerBankName { get; init; }
    public string PayerBankSwiftCode { get; init; }
    public string PayerAccountNumber { get; init; }
    public string PayerCorrAccountNumber { get; init; }
    public string PayerName { get; init; }
    public string PaymentPurpose { get; init; }
    public string DocumentNumber { get; init; }
    public DateTime ChargeDate { get; init; }
}