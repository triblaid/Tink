namespace Project.Application;

public record GetVirtualAccountBalancesQuery
{
    public string AccountNumber { get; init; }
    public Guid BeneficiaryId { get; init; }
    public int Offset { get; init; }
    public int Limit { get; init; }

    public GetVirtualAccountBalancesQuery(string accountNumber, Guid beneficiaryId, int offset, int limit)
    {
        AccountNumber = accountNumber;
        BeneficiaryId = beneficiaryId;
        Offset = offset; 
        Limit = limit;
    }
}