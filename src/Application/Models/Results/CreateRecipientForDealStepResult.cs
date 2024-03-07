namespace Project.Application;

public record CreateRecipientForDealStepResult : TinkoffRequestResult
{
    public Guid RecipientId { get; init; }
}
