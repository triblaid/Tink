namespace Project;

public partial class LegalEntity : Projection
{
    public string Name { get; private set; }
    public int Number { get; private set; }
    public string Email { get; private set; }
    public string Tin { get; private set; }
    public string Psrn { get; private set; }
    public string LegalAddress { get; private set; }
    public string Trrc { get; private set; }

    public LegalEntity(Guid id) : base(id) { }

    private void Apply(LegalEntityRegistered change)
    {
        var legalEntityProfile = change.Profile;

        Name = legalEntityProfile.Name;
        Tin = legalEntityProfile.Tin;
        Psrn = legalEntityProfile.Psrn;
        LegalAddress = legalEntityProfile.LegalAddress;
        Trrc = legalEntityProfile.Trrc;
        Number = change.Number;
        Email = change.Email;
    }

    private void Apply(LegalEntityChanged change)
    {
        if(change.Email.IsSet) Email = change.Email;
    }
}
