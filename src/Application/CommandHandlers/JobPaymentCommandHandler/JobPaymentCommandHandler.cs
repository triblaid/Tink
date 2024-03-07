namespace Project.Application;

public partial class JobPaymentCommandHandler
{
    private readonly ICommandRepository _messages;
    private readonly ITinkoffService _tinkoffService;
    private readonly IDealRepository _dealRepository;
    private readonly IWorkerBeneficiaryRepository _workerBeneficiaryRepository;
    private readonly ILegalEntityBeneficiaryRepository _legalEntityBeneficiaryRepository;

    public JobPaymentCommandHandler(
        ICommandRepository messages,
        ITinkoffService tinkoffService,
        IDealRepository dealRepository,
        IWorkerBeneficiaryRepository workerBeneficiaryRepository,
        ILegalEntityBeneficiaryRepository legalEntityBeneficiaryRepository)
    {
        _messages = messages;
        _tinkoffService= tinkoffService;
        _dealRepository = dealRepository;
        _workerBeneficiaryRepository = workerBeneficiaryRepository;
        _legalEntityBeneficiaryRepository = legalEntityBeneficiaryRepository;
    }
}