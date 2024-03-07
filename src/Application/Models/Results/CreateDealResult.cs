namespace Project.Application;

public record CreateDealResult : TinkoffRequestResult
{
    public Guid DealId { get; init; }
}
