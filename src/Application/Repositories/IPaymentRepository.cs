namespace Project.Application;

public interface IPaymentRepository : IRepository<Payment>
{
    Task<List<Payment>> GetAllPending();
    Task<Payment> GetByWithdrawalId(Guid id);
}
