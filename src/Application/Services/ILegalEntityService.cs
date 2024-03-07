namespace Project.Application;

public interface ILegalEntityService : IService
{
    Task<LegalEntity> GetById(Guid id);
}

