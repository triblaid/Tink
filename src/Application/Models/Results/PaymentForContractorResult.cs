namespace Project.Application;

public record PaymentResult : TinkoffRequestResult
{
    public Guid PaymentId { get; init; }
    public WithdrawalStatus Status { get; init; }
}