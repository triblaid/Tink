using System.Text.Json.Serialization;

namespace Project.Application;

public record CreateDeponentRequest : IIdempotency
{
    public Guid DealId { get; init; }
    public Guid StepId { get; init; }
    public Guid BeneficiaryId { get; init; }
    public decimal Amount { get; init; }
    [JsonIgnore]
    public Guid IdempotencyKey { get; init; }
}

