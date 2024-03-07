using System.Text.Json.Serialization;

namespace Project.Application;

public interface IIdempotency
{
    [JsonIgnore]
    public Guid IdempotencyKey { get; }
}