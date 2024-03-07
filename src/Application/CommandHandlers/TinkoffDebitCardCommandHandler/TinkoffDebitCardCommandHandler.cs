namespace Project.Application;

public partial class TinkoffDebitCardCommandHandler
{
    private readonly ILogger _logger;
    private readonly ICommandRepository _messages;
    private readonly ITinkoffService _tinkoffService;
    private readonly IDebitCardRepository _debitCardRepository;
    private readonly IWorkerBeneficiaryRepository _workerBeneficiaryRepository;
    private readonly RpcClient _rpcClient;

    public TinkoffDebitCardCommandHandler(
        ILogger logger,
        ICommandRepository messages,
        ITinkoffService tinkoffService,
        IDebitCardRepository debitCardRepository,
        IWorkerBeneficiaryRepository workerBeneficiaryRepository,
        RpcClient rpcClient)
    {
        _logger = logger;
        _messages = messages;
        _tinkoffService = tinkoffService;
        _debitCardRepository = debitCardRepository;
        _workerBeneficiaryRepository = workerBeneficiaryRepository;
        _rpcClient = rpcClient;
    }
}
