namespace Project.Application;

public record CreateBeneficiaryLegalEntityRequest : CreateBeneficiaryRequest
{
    public string Name { get; init; }
    public string Ogrn { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public override string Type => "UL_RESIDENT";

    public CreateBeneficiaryLegalEntityRequest(LegalEntity legalEntity)
    {
        Name = legalEntity.Name;
        Email = legalEntity.Email;
        Inn = legalEntity.Tin;
        Ogrn = legalEntity.Psrn;
        Addresses = new List<BeneficiaryAddresses> {
                new BeneficiaryAddresses
                {
                    Address = legalEntity.LegalAddress,
                    Type = "LEGAL_ENTITY_ADDRESS"
                }
            };
    }
}