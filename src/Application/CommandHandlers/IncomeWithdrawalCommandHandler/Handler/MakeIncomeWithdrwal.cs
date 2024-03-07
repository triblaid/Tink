namespace Project.Application;

public partial class IncomeWithdrawalCommandHandler : ICommandHandler<MakeIncomeWithdrawal>
{
    public async Task Handle(CommandArgs<MakeIncomeWithdrawal> args)
    {
        var (workerId, debitCardId, amount, withdrawalId) = args.Payload;
        var debitCard = await _debitCardRepository.GetById(debitCardId);
        var workerBeneficiary = await _workerBeneficiaryRepository.GetByWorkerId(workerId);

        var result = await _tinkoffService.CreatePayment(debitCard.BankDetailsId, workerBeneficiary.BeneficiaryId, withdrawalId, amount);

        var payment = new Payment(workerBeneficiary.BeneficiaryId, result.PaymentId, debitCard.BankDetailsId, withdrawalId, amount);
        _paymentRepository.Add(payment);
    }
}