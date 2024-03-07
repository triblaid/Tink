namespace Project.Application;

public partial class IncomeWithdrawalCommandHandler : ICommandHandler<UpdateIncomeWithdrawalStatus>
{
    public async Task Handle(CommandArgs<UpdateIncomeWithdrawalStatus> args)
    {
        var (withdrawalId, status, error) = args.Payload;
        var payment = await _paymentRepository.GetByWithdrawalId(withdrawalId);

        if (status == WithdrawalStatus.Succeeded)
        {
            _messages.Add(new CompleteIncomeWithdrawal(payment.WithdrawalId));

            payment.ConfirmSucceeded();
        }

        if (status == WithdrawalStatus.Failed || status == WithdrawalStatus.Cancelled)
        {
            _messages.Add(new DeclineIncomeWithdrawal(payment.WithdrawalId, error));
            payment.ConfirmFailed();
        }
    }
}
