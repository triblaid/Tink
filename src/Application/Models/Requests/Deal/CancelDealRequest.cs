namespace Project.Application;

public record CancelDealRequest
{
    public Guid DealId { get; init; }
}