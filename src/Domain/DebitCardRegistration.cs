namespace Project;

public class DebitCardRegistration
{
    public Guid DebitCardId { get; set; }
    public Guid RegistrationRequestId { get; set; }
    public Guid BeneficiaryId { get; set; }
    public Guid BankDetailsId { get; set; }
    public DebitCardRegistrationStatus Status { get; set; }
    public string RegistrationUrl { get; set; }
    public bool IsDeleted { get; set; }

    private DebitCardRegistration() { }

    public DebitCardRegistration(
        Guid debitCardId,
        Guid registrationRequestId,
        Guid beneficiaryId,
        string registrationUrl)
    {
        if (debitCardId == Guid.Empty) throw new BehaviourException("debitCardId can't be empty uuid");
        if (registrationRequestId == Guid.Empty) throw new BehaviourException("registrationRequestId can't be empty uuid");
        if (beneficiaryId == Guid.Empty) throw new BehaviourException("beneficiaryId can't be empty uuid");
        if (string.IsNullOrWhiteSpace(registrationUrl)) throw new BehaviourException("registrationUrl can't be empty string");

        DebitCardId = debitCardId;
        RegistrationRequestId = registrationRequestId;
        Status = DebitCardRegistrationStatus.Pending;
        BeneficiaryId = beneficiaryId;
        RegistrationUrl = registrationUrl;
    }

    public void UpdateBankDetailsId(Guid bankDetailsId)
    {
        if (bankDetailsId == Guid.Empty) throw new BehaviourException("bankDetailsId can't be empty uuid");

        BankDetailsId = bankDetailsId;
    }

    public void UpdateRegistration(string registrationUrl, DebitCardRegistrationStatus status)
    {
        if (string.IsNullOrWhiteSpace(registrationUrl)) throw new BehaviourException("registrationUrl can't be empty string");
        RegistrationUrl = registrationUrl;
        Status = status;
    }

    public void UpdateTinkoffCardStatus(DebitCardRegistrationStatus status)
    {
        Status = status;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
