namespace Project.Application;

public partial class TinkoffQueryHandler
{
    private readonly ITinkoffService _tinkoffService;
    private readonly ILegalEntityService _legalEntityService;
    private readonly ICounterClient _counterClient;
    private readonly ILegalEntityAgreementRepository _legalEntityAgreementRepository;
    private readonly IDebitCardRepository _debitCardRepository;
    private readonly IIncomingTransactionRepository _incomingTransactionsRepository;
    private readonly ILegalEntityBeneficiaryRepository _legalEntityBeneficiaryRepository;
    private readonly IWorkerBeneficiaryRepository _workerBeneficiaryRepository;
    private readonly IWorkerFfmsStatusService _workerFfmsStatusService;
    private readonly IWorkerFfmsStatusRepository _workerFfmsStatusRepository;
    private readonly ILogger _logger;
    private readonly ICommandRepository _messages;
    private readonly RpcClient _rpcClient;

    public TinkoffQueryHandler(ITinkoffService tinkoffService,
        ILegalEntityService legalEntityService,
        ICounterClient counterClient,
        ILegalEntityAgreementRepository legalEntityAgreementRepository,
        IDebitCardRepository debitCardRepository,
        IIncomingTransactionRepository incomingTransactionRepository,
        ILegalEntityBeneficiaryRepository legalEntityBeneficiaryRepository,
        IWorkerBeneficiaryRepository workerBeneficiaryRepository,
        IWorkerFfmsStatusRepository workerWorkerFfmsStatusRepository,
        IWorkerFfmsStatusService workerFfmsStatusService,
        ILogger logger,
        ICommandRepository messages,
        RpcClient rpcClient)
    {
        _tinkoffService = tinkoffService;
        _legalEntityService = legalEntityService;
        _counterClient = counterClient;
        _legalEntityAgreementRepository = legalEntityAgreementRepository;
        _debitCardRepository = debitCardRepository;
        _incomingTransactionsRepository = incomingTransactionRepository;
        _legalEntityBeneficiaryRepository = legalEntityBeneficiaryRepository;
        _workerBeneficiaryRepository = workerBeneficiaryRepository;
        _workerFfmsStatusRepository = workerWorkerFfmsStatusRepository;
        _workerFfmsStatusService = workerFfmsStatusService;
        _logger = logger;
        _messages = messages;
        _rpcClient = rpcClient;
    }
}