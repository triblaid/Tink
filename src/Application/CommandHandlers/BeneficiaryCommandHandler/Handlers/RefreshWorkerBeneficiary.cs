namespace Project.Application;

public partial class BeneficiaryCommandHandler : ICommandHandler<RefreshWorkerBeneficiary>
{
    public async Task Handle(CommandArgs<RefreshWorkerBeneficiary> args)
    {
        var workerId = args.Payload.WorkerId;

        var worker = await _workerService.GetById(workerId);
        var workerBeneficiary = await _workerBeneficiaryRepository.GetByWorkerId(workerId);

        var request = new UpdateBeneficiaryWorkerRequest(workerBeneficiary, worker);

        var beneficiary = await _tinkoffService.UpdateBeneficiaryWorker(request);

        if (!beneficiary.IsSuccess)
        {
            _logger.LogError("Error occurred in Tinkoff for command {commandName} with args {args}, error : {tinkoffError}",
                nameof(RefreshWorkerBeneficiary), args.Payload.ToJsonElement(), beneficiary.Error);
        }

        var scoreRequest = new GetBeneficiaryScoringRequest { BeneficiaryId = workerBeneficiary.BeneficiaryId };
        var response = await _tinkoffService.GetBeneficiaryScoring(scoreRequest);

        await _workerFfmsStatusService.CheckWorkerFfmsStatus(workerBeneficiary.BeneficiaryId, worker.Id, response);
    }
}