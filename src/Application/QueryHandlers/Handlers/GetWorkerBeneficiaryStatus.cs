namespace Project.Application;

public partial class TinkoffQueryHandler : IQueryHandler<GetWorkerBeneficiaryStatus, GetBeneficiaryScoringResult>
{
    public async Task<GetBeneficiaryScoringResult> Handle(QueryArgs<GetWorkerBeneficiaryStatus> args)
    {
        var workerId = args.Payload.WorkerId;

        var workerBeneficiary = await _workerBeneficiaryRepository.GetByWorkerId(workerId);

        var request = new GetBeneficiaryScoringRequest() { BeneficiaryId = workerBeneficiary.BeneficiaryId };

        var result = await _tinkoffService.GetBeneficiaryScoring(request);

        if (!result.IsSuccess)
        {
            _logger.LogError("Unable get scoring for beneficiary: {beneficiaryId}, due to {error}", workerBeneficiary.BeneficiaryId, result.Error);
            return new GetBeneficiaryScoringResult();
        }

        return result.Results.FirstOrDefault();
    }
}