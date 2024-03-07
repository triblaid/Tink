namespace Project;

public partial class LegalEntityAgreementNumber : Projection
{
    public string Number { get; private set; }

    public LegalEntityAgreementNumber(Guid id) : base(id) { }

    private void Apply(LegalEntityDocumentsApproved change)
    {
        Number = change.AgreementNumber;
    }

    private void Apply(LegalEntityAgreementAccepted change)
    {
        Number = change.Number;
    }
}
