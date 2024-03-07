namespace Project.Application;

public record CreateBeneficiaryWorkerRequest : CreateBeneficiaryRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsSelfEmployed { get; set; } = true;
    public DateOnly BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Citizenship { get; set; } = "RU";
    public override string Type => "FL_RESIDENT";
    public List<ContractorDocument> Documents { get; set; }

    public CreateBeneficiaryWorkerRequest(Worker worker, string address)
    {
        FirstName = worker.Forename;
        LastName = worker.Surname;
        BirthDate = worker.DateOfBirth;
        PhoneNumber = worker.PhoneNumber;
        Citizenship = worker.Citizenship;
        Inn = worker.Tin;
        Documents = new List<ContractorDocument> {
                new ContractorDocument {
                    Serial = worker.PassportSeries,
                    Number = worker.PassportNumber,
                    Date = worker.PassportDateOfIssue,
                    Organization = worker.PassportAuthority,
                    Division = worker.PassportSubdivisionCode
                }
            };
        Addresses = new List<BeneficiaryAddresses> {
                new BeneficiaryAddresses
                {
                    Type = "REGISTRATION_ADDRESS",
                    Address = address,
                }
            };
    }
}

public record ContractorDocument
{
    public string Type { get; set; } = "PASSPORT";
    public string Serial { get; set; }
    public string Number { get; set; }
    public DateOnly Date { get; set; }
    public string Organization { get; set; }
    public string Division { get; set; }
}