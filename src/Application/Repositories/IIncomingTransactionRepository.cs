namespace Project.Application;

public interface IIncomingTransactionRepository : IRepository<LegalEntityIncomingTransaction>
{
    Task<LegalEntityIncomingTransaction> GetById(Guid id);
    Task<LegalEntityIncomingTransaction> FindById(Guid id);
}