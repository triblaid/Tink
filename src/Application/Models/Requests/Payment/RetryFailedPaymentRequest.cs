namespace Project.Application;

public record RetryFailedPaymentRequest
{
    public Guid RetryPaymentId { get; init; }
}