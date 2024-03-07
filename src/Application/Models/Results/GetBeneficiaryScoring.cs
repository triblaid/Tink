using Project.Application;

namespace Project;

public record GetTinkoffBeneficiaryScoringPageResult : TinkoffPageResult
{
    public List<GetBeneficiaryScoringResult> Results { get; set; }
}