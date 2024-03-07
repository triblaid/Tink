namespace Project.Application;

public interface IDebitCardRepository : IRepository<DebitCardRegistration>
{
    Task<List<DebitCardRegistration>> GetByStatusPending();
    Task<DebitCardRegistration> FindById(Guid id);
    Task<DebitCardRegistration> GetById(Guid id);
}
