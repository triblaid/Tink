namespace Project.Application;

public record UpdateBeneficiaryWorkerResult : TinkoffRequestResult
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public bool IsSelfEmployed { get; set; } = true;
    public DateOnly BirthDate { get; set; }
    public string BirthPlace { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Snils { get; set; }
    public string Citizenship { get; set; } = "RU";
    public List<ContractorDocument> Documents { get; set; }
    public List<BeneficiaryAddresses> Addresses { get; set; }
}