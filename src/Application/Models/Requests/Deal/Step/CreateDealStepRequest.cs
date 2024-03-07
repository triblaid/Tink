using System.Text.Json.Serialization;

namespace Project.Application;

public record CreateDealStepRequest : IIdempotency
{
    public Guid DealId { get; init; }
    public string Description { get; init; }
    [JsonIgnore]
    public Guid IdempotencyKey { get; private init; }

    public CreateDealStepRequest(
        Guid id,
        Guid dealId,
        string description)
    {
        IdempotencyKey = id;
        DealId = dealId;
        Description = description;
    }
}
