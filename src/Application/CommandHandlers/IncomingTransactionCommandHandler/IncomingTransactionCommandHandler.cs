namespace Project.Application;

public partial class IncomingTransactionCommandHandler
{
    private readonly ILogger _logger;
    private readonly ITinkoffService _tinkoffService;
    private readonly ICommandRepository _messages;
    private readonly IIncomingTransactionRepository _incomingTransactionsRepository;
    private readonly ILegalEntityBeneficiaryRepository _legalEntityBeneficiaryRepository;
    private readonly RpcClient _rpcClient;

    public IncomingTransactionCommandHandler(
        ILogger logger,
        ITinkoffService tinkoffService,
        ICommandRepository commandRepository,
        IIncomingTransactionRepository incomingTransactionsRepository,
        ILegalEntityBeneficiaryRepository legalEntityBeneficiaryRepository,
        RpcClient rpcClient)
    {
        _logger = logger;
        _messages = commandRepository;
        _tinkoffService = tinkoffService;
        _incomingTransactionsRepository = incomingTransactionsRepository;
        _legalEntityBeneficiaryRepository = legalEntityBeneficiaryRepository;
        _rpcClient = rpcClient;
    }
}