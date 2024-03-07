namespace Project.Application;

public record UpdateBeneficiaryWorkerRequest : CreateBeneficiaryRequest
{
    public Guid BeneficiaryId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsSelfEmployed { get; set; } = true;
    public DateOnly BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Citizenship { get; set; } = "RU";
    public override string Type => "FL_RESIDENT";
    public List<ContractorDocument> Documents { get; set; }
    public UpdateBeneficiaryWorkerRequest(WorkerBeneficiary beneficiary, Worker worker)
    {
        BeneficiaryId = beneficiary.BeneficiaryId;
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
                    Address = beneficiary.Address,
                }
            };
    }
}