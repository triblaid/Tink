namespace Project.Application;

public record GetDebitCardRequestResult : TinkoffRequestResult, IBeneficiary
{
    public DebitCardRegistrationStatus Status { get; init; }
    public Guid BankDetailsId { get; init; }
    public Guid BeneficiaryId { get; init; }
}
