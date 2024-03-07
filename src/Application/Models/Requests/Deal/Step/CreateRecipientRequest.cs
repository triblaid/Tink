using System.Text.Json.Serialization;

namespace Project.Application;

public record CreateRecipientRequest : IIdempotency
{
    public Guid DealId { get; init; }
    public Guid StepId { get; init; }
    public Guid BeneficiaryId { get; init; }
    public decimal Amount { get; init; }
    public string Purpose { get; init; }
    public readonly bool KeepOnVirtualAccount = true;
    [JsonIgnore]
    public Guid IdempotencyKey { get; init; }
}