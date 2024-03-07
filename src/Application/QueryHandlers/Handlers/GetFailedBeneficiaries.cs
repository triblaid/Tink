namespace Project.Application;

public partial class TinkoffQueryHandler : IQueryHandler<GetFailedBeneficiaries, GetBeneficiaryScoringPageResult>
{
    public async Task<GetBeneficiaryScoringPageResult> Handle(QueryArgs<GetFailedBeneficiaries> args)
    {
        var request = new GetBeneficiaryScoringRequest() { Passed = false };

        var result = await _tinkoffService.GetBeneficiaryScoring(request);

        if (!result.IsSuccess)
        {
            _logger.LogError("Unable get failed beneficiaries due to {error}", result.Error);
            return new GetBeneficiaryScoringPageResult();
        }

        return new GetBeneficiaryScoringPageResult
        {
            Limit = result.Limit,
            Offset = result.Offset,
            Size = result.Size,
            Total = result.Total,
            Results = result.Results
        };
    }
}