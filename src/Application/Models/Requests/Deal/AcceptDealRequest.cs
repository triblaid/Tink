namespace Project.Application;

public record AcceptDealRequest
{
    public Guid DealId { get; init; }

    public AcceptDealRequest(Guid dealId)
    {
        DealId = dealId;
    }
}