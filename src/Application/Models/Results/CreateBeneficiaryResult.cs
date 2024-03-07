namespace Project.Application;

public record CreateBeneficiaryResult : TinkoffRequestResult
{
    public Guid BeneficiaryId { get; init; }
}

