using System.Text.Json.Serialization;

namespace Project.Application;

public record CreateDebitCardRequestRequest : IIdempotency
{
    public Guid BeneficiaryId { get; init; }
    public string TerminalKey { get; init; }

    [JsonIgnore]
    public Guid IdempotencyKey { get; init; }

    public CreateDebitCardRequestRequest(Guid workerBeneficiaryId, Guid commandId, string terminalKey)
    {
        BeneficiaryId = workerBeneficiaryId;
        IdempotencyKey = commandId;
        TerminalKey = terminalKey;
    }
}