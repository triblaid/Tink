namespace Project.Application;

public record CreateDealStepResult : TinkoffRequestResult
{
    public Guid StepId { get; init; }
    public Guid DealId { get; init; }
    public int Number { get; init; }
    public string Description { get; init; }
}