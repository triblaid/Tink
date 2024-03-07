using System.Text.Json.Serialization;

namespace Project.Application;

public interface IBeneficiary
{
    [JsonIgnore]
    public Guid BeneficiaryId { get; init; }
}
