namespace Project;

public record Payment
{
    public Guid WithdrawalId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid BeneficiaryId { get; set; }
    public Guid BankDetailsId { get; set; }
    public decimal Amount { get; set; }
    public WithdrawalStatus Status { get; set; }

    private Payment() { }

    public Payment(Guid beneficiaryId, Guid paymentId, Guid bankDetailsId, Guid withdrawalId, decimal amount)
    {
        if (beneficiaryId == Guid.Empty) throw new BehaviourException("beneficiaryId can't be empty uuid");
        if (paymentId == Guid.Empty) throw new BehaviourException("paymentId can't be empty uuid");
        if (bankDetailsId == Guid.Empty) throw new BehaviourException("bankDetailsId can't be empty uuid");
        if (withdrawalId == Guid.Empty) throw new BehaviourException("withdrawalId can't be empty uuid");

        if (amount <= 0) throw new BehaviourException("amount can't be less than 0");

        BeneficiaryId = beneficiaryId;
        PaymentId = paymentId;
        BankDetailsId = bankDetailsId;
        WithdrawalId = withdrawalId;
        Amount = amount;
        Status = WithdrawalStatus.Pending;
    }

    public void ConfirmSucceeded()
    {
        Status = WithdrawalStatus.Succeeded;
    }

    public void ConfirmFailed()
    {
        Status = WithdrawalStatus.Failed;
    }
}
