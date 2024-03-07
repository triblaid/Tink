namespace Project.Application;

public record CompleteDealStepRequest
{
    public Guid DealId { get; init; }
    public Guid StepId { get; init; }

    public CompleteDealStepRequest(Guid dealId, Guid stepId)
    {
        DealId = dealId;
        StepId = stepId;
    }
}
