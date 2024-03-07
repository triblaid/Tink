namespace Project.Application;

public partial class IncomeWithdrawalCommandHandler
{
    private readonly ICommandRepository _messages;
    private readonly ITinkoffService _tinkoffService;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IDebitCardRepository _debitCardRepository;
    private readonly IWorkerBeneficiaryRepository _workerBeneficiaryRepository;
    private readonly RpcClient _rpcClient;
    private readonly ILogger _logger;

    public IncomeWithdrawalCommandHandler(
        ITinkoffService tinkoffService,
        ICommandRepository outboxRepository,
        IPaymentRepository paymentRepository,
        IDebitCardRepository debitCardRepository,
        IWorkerBeneficiaryRepository workerBeneficiaryRepository,
        RpcClient rpcClient,
        ILogger logger)
    {
        _messages = outboxRepository;
        _tinkoffService = tinkoffService;
        _paymentRepository = paymentRepository;
        _debitCardRepository = debitCardRepository;
        _workerBeneficiaryRepository = workerBeneficiaryRepository;
        _rpcClient = rpcClient;
        _logger = logger;
    }
}
