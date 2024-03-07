namespace Project.Application;

public partial class IncomeWithdrawalCommandHandler : IQueryHandler<CheckIncomeWithdrawals, bool>
{
    public async Task<bool> Handle(QueryArgs<CheckIncomeWithdrawals> args)
    {
        var payments = await _paymentRepository.GetAllPending(); // TODO: optimize for partitioning

        foreach (var payment in payments)
        {
            var paymentResult = await _tinkoffService.GetPaymentById(payment.PaymentId);

            if (paymentResult.Status != WithdrawalStatus.Pending)
                UpdateIncomeWithdrawal(payment.WithdrawalId, paymentResult);
        }
        return true;
    }

    private async void UpdateIncomeWithdrawal(Guid withdrawalId, PaymentResult paymentResult)
    {
        var updateIncomeWithdrawal = new UpdateIncomeWithdrawalStatus(withdrawalId, paymentResult.Status, paymentResult.Error);
        var response = await _rpcClient.Send(updateIncomeWithdrawal);

        if (response.Status != RpcStatus.Ok)
            _logger.LogError("Error occurred while updating withdrawal = {withdrawalId} to status = {status}. Error: {error}",
                withdrawalId, paymentResult.Status, response.Message);

    }
}
