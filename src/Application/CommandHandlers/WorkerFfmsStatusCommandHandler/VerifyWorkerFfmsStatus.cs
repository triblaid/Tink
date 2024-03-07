namespace Project.Application;

public partial class WorkerFfmsStatusCommandHandler : ICommandHandler<VerifyWorkerFfmsStatus>
{
    public async Task Handle(CommandArgs<VerifyWorkerFfmsStatus> args)
    {
        var beneficiary = await _workerBeneficiaryRepository.GetByWorkerId(args.Payload.WorkerId);

        var request = new GetBeneficiaryScoringRequest { BeneficiaryId = beneficiary.BeneficiaryId };
        var response = await _tinkoffService.GetBeneficiaryScoring(request);

        await _workerFfmsStatusService.CheckWorkerFfmsStatus(beneficiary.BeneficiaryId, beneficiary.WorkerId, response);
    }
}