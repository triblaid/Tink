namespace Project.Application;

public record CreatePaymentQuery : IIdempotency
{
    public string Type = "REGULAR";

    private static string _accountNumber = Environment.GetEnvironmentVariable("TINKOFF_PROJECT_ACCOUNT_NUMBER");
    public string AccountNumber => string.IsNullOrWhiteSpace(_accountNumber) ? throw new Exception("Account number must be set") : _accountNumber;
    public Guid BeneficiaryId { get; init; }
    public Guid IdempotencyKey { get; init; }
    public Guid BankDetailsId { get; init; }
    public decimal Amount { get; init; }
    public string Purpose { get; init; }

    public CreatePaymentQuery(Guid bankDetailsId, Guid workerBeneficiary, Guid withdrawalId, decimal amount)
    {
        BankDetailsId = bankDetailsId;
        BeneficiaryId = workerBeneficiary;
        IdempotencyKey = withdrawalId;
        Amount = amount;
        Purpose = withdrawalId.ToString();
    }
}