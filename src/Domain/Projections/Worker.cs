namespace Project;

public partial class Worker : Projection
{
    public string Surname { get; private set; }
    public string Forename { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string Tin { get; private set; }
    public string Citizenship { get; private set; }
    public string PassportSeries { get; private set; }
    public string PassportNumber { get; private set; }
    public DateOnly PassportDateOfIssue { get; set; }
    public string PassportSubdivisionCode { get; set; }
    public string PassportAuthority { get; set; }
    public bool Deleted { get; set; }
    public bool Deactivated { get; set; }
    public bool InActive => Deactivated || Deleted;


    public Worker(Guid id) : base(id) { }

    private void Apply(WorkerRegistered worker)
    {
        var passportDetails = worker.PassportDetails.ToJsonString().ParseJson<RussianPassport>();

        Tin = worker.Tin;
        PhoneNumber = worker.PhoneNumber;
        Surname = passportDetails.Surname;
        Forename = passportDetails.Forename;
        DateOfBirth = passportDetails.DateOfBirth.Value;
        PassportNumber = passportDetails.Number;
        PassportSeries = passportDetails.Series;
        PassportDateOfIssue = passportDetails.DateOfIssue.Value;
        PassportSubdivisionCode = passportDetails.SubdivisionCode;
        PassportAuthority = passportDetails.Authority;
        Citizenship = passportDetails.Citizenship.ToString().ToUpper();
    }

    private void Apply(WorkerPassportDetailsChanged worker)
    {
        var passportDetails = worker.PassportDetails.ToJsonString().ParseJson<RussianPassport>();

        Surname = passportDetails.Surname;
        Forename = passportDetails.Forename;
        DateOfBirth = passportDetails.DateOfBirth.Value;
        PassportNumber = passportDetails.Number;
        PassportSeries = passportDetails.Series;
        PassportDateOfIssue = passportDetails.DateOfIssue.Value;
        PassportSubdivisionCode = passportDetails.SubdivisionCode;
        PassportAuthority = passportDetails.Authority;
        Citizenship = passportDetails.Citizenship.ToString().ToUpper();
    }

    private void Apply(WorkerDeactivated change) => Deactivated = true;
    private void Apply(WorkerActivated change) => Deactivated = false;
    private void Apply(WorkerDeleted change) => Deleted = true;
}
