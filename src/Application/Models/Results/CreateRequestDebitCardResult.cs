namespace Project.Application;

public record CreateDebitCardRequestResult : TinkoffRequestResult, IBeneficiary
{
    public DebitCardRegistrationStatus Status { get; init; }
    public Guid AddCardRequestId { get; init; }
    public Guid BeneficiaryId { get; init; }
    public string AddCardUrl { get; init; }
}
