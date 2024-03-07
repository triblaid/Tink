namespace Project.Application;

public partial class BeneficiaryCommandHandler
{
    private readonly ICommandRepository _messages;
    private readonly IWorkerService _workerService;
    private readonly ITinkoffService _tinkoffService;
    private readonly ILegalEntityService _legalEntityService;
    private readonly IWorkerBeneficiaryRepository _workerBeneficiaryRepository;
    private readonly ILegalEntityBeneficiaryRepository _legalEntityBeneficiaryRepository;
    private readonly IWorkerFfmsStatusService _workerFfmsStatusService;
    private readonly ILogger _logger;

    public BeneficiaryCommandHandler(
        ICommandRepository messages,
        IWorkerService workerService,
        ILegalEntityService legalEntityService,
        ITinkoffService tinkoffService,
        IWorkerBeneficiaryRepository workerBeneficiaryRepository,
        ILegalEntityBeneficiaryRepository legalEntityBeneficiaryRepository,
        IWorkerFfmsStatusService workerFfmsStatusService,
        ILogger logger)
    {
        _messages = messages;
        _workerService = workerService;
        _tinkoffService = tinkoffService;
        _legalEntityService = legalEntityService;
        _workerBeneficiaryRepository = workerBeneficiaryRepository;
        _legalEntityBeneficiaryRepository = legalEntityBeneficiaryRepository;
        _workerFfmsStatusService = workerFfmsStatusService;
        _logger = logger;
    }
}