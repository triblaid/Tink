namespace Project.Application;

public partial class IncomingTransactionCommandHandler : IQueryHandler<CheckIncomingTransactions, bool>
{
    public async Task<bool> Handle(QueryArgs<CheckIncomingTransactions> args)
    {
        var incomingTransactions = await _tinkoffService.GetIncomingTransactions();
        foreach (var transaction in incomingTransactions)
            AssignIncomingTransaction(transaction);

        return true;
    }

    private async void AssignIncomingTransaction(IncomingTransaction transaction)
    {
        var assignTransaction = new AssignIncomingTransaction(transaction.Id, transaction.Tin, transaction.Amount);
        var response = await _rpcClient.Send(assignTransaction);

        if (response.Status != RpcStatus.Ok) 
            _logger.LogWarning("Error occurred while assigning incomingTransaction = {id}. Error: {error}",
                transaction.Id, response.Message);
    }
}
