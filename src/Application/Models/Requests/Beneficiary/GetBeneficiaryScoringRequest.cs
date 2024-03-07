namespace Project.Application;

public record GetBeneficiaryScoringRequest
{
    public Guid? BeneficiaryId { get; set; }
    public bool? Passed { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}