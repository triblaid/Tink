namespace Project.Application;

public partial class BeneficiaryCommandHandler : ICommandHandler<CreateWorkerBeneficiary>
{
    public async Task Handle(CommandArgs<CreateWorkerBeneficiary> args)
    {
        var (workerId, address) = args.Payload;

        var worker = await _workerService.GetById(workerId);

        var request = new CreateBeneficiaryWorkerRequest(worker, address);

        var beneficiary = await _tinkoffService.CreateBeneficiary(request);

        if (!beneficiary.IsSuccess)
        {
            var createTechnicalIssue = new CreateTechnicalIssue(TechnicalIssuesType.WorkerBeneficiaryCreation, beneficiary.Error, args.Payload.ToJsonElement());
            _messages.Add(createTechnicalIssue);
            return;
        }

        var workerBeneficiary = new WorkerBeneficiary(beneficiary.BeneficiaryId, worker.Id, address);

        _workerBeneficiaryRepository.Add(workerBeneficiary);

        var scoreRequest = new GetBeneficiaryScoringRequest { BeneficiaryId = beneficiary.BeneficiaryId };
        var response = await _tinkoffService.GetBeneficiaryScoring(scoreRequest);

        await _workerFfmsStatusService.CheckWorkerFfmsStatus(workerBeneficiary.BeneficiaryId, worker.Id, response);
    }
}
