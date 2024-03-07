using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Project.Application;

public record CreateBeneficiaryRequest : IIdempotency
{
    public string Inn { get; init; }
    public virtual string Type { get; }
    public List<BeneficiaryAddresses> Addresses { get; init; }

    [JsonIgnore]
    public Guid IdempotencyKey
    {
        get
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(Inn));
                return new Guid(hash);
            }
        }
    }
}

public record BeneficiaryAddresses
{
    public string Type { get; init; }
    public string Address { get; init; }
}