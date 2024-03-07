namespace Project.Application;

public interface ILegalEntityAgreementRepository : IRepository<LegalEntityAgreement>
{
    Task<LegalEntityAgreement> FindByIdLegalEntityId(Guid legalEntityId);
    Task<string> GetLegalEntityAgreementNumber(Guid id);
}
