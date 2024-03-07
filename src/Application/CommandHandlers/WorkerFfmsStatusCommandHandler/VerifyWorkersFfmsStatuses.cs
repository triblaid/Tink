namespace Project.Application;

public partial class WorkerFfmsStatusCommandHandler : ICommandHandler<VerifyWorkersFfmsStatuses>
{
    private readonly ITinkoffService _tinkoffService;
    private readonly IWorkerFfmsStatusService _workerFfmsStatusService;
    private readonly IWorkerBeneficiaryRepository _workerBeneficiaryRepository;
    private readonly ILogger _logger;

    public WorkerFfmsStatusCommandHandler(
        ITinkoffService tinkoffService,
        IWorkerBeneficiaryRepository workerBeneficiaryRepository,
        IWorkerFfmsStatusService workerFfmsStatusService,
        ILogger logger)
    {
        _tinkoffService = tinkoffService;
        _workerBeneficiaryRepository = workerBeneficiaryRepository;
        _workerFfmsStatusService = workerFfmsStatusService;
        _logger = logger;
    }

    public async Task Handle(CommandArgs<VerifyWorkersFfmsStatuses> args)
    {
        var workerBeneficiaries = await _workerBeneficiaryRepository.GetAllBeneficiaries();

        foreach (var workerBeneficiary in workerBeneficiaries)
        {
            var scoringRequest = new GetBeneficiaryScoringRequest() { BeneficiaryId = workerBeneficiary.BeneficiaryId };
            var response = await _tinkoffService.GetBeneficiaryScoring(scoringRequest);

            await _workerFfmsStatusService.CheckWorkerFfmsStatus(workerBeneficiary.BeneficiaryId, workerBeneficiary.WorkerId, response);
        }
    }
}