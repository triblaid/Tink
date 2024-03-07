namespace Project;

public record LegalEntityBeneficiary
{
    public Guid BeneficiaryId { get; set; }
    public Guid LegalEntityId { get; set; }
    public string Tin { get; set; }

    private LegalEntityBeneficiary() { }
    public LegalEntityBeneficiary(Guid beneficiaryId, Guid legalEntityId, string tin)
    {
        if (beneficiaryId == Guid.Empty) throw new BehaviourException("beneficiaryId can't be empty uuid");
        if (legalEntityId == Guid.Empty) throw new BehaviourException("legalEntityId can't be empty uuid");
        if (string.IsNullOrWhiteSpace(tin)) throw new BehaviourException("tin can't be empty string");

        BeneficiaryId = beneficiaryId;
        LegalEntityId = legalEntityId;
        Tin = tin;
    }
}