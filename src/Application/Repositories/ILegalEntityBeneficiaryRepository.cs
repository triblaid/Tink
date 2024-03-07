namespace Project.Application;

public interface ILegalEntityBeneficiaryRepository : IRepository<LegalEntityBeneficiary>
{
    Task<LegalEntityBeneficiary> GetByTin(string tin);
    Task<LegalEntityBeneficiary> FindByTin(string tin);
    Task<LegalEntityBeneficiary> FindByLegalEntityId(Guid legalEntityId);
    Task<LegalEntityBeneficiary> GetByLegalEntityId(Guid legalEntityId);
}