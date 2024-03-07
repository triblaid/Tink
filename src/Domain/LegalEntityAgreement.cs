namespace Project;

public record LegalEntityAgreement
{
    public Guid AgreementId { get; set; }
    public Guid LegalEntityId { get; set; }

    private LegalEntityAgreement() { }
    public LegalEntityAgreement(Guid agreementId, Guid legalEntityId)
    {
        LegalEntityId = legalEntityId;
        AgreementId = agreementId;
    }
}
