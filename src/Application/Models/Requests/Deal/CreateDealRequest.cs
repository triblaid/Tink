using System.Text.Json.Serialization;

namespace Project.Application;

public record CreateDealRequest : IIdempotency
{
    private static string _accountNumber = Environment.GetEnvironmentVariable("TINKOFF_PROJECT_ACCOUNT_NUMBER");

    [JsonIgnore]
    public Guid IdempotencyKey { get; init; }
    public string AccountNumber => string.IsNullOrWhiteSpace(_accountNumber) ? throw new Exception("Account number must be set") : _accountNumber;

    public CreateDealRequest(Guid id)
    { 
        IdempotencyKey = id;
    }
}