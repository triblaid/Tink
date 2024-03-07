namespace Project.Application;

public interface IWorkerBeneficiaryRepository : IRepository<WorkerBeneficiary>
{
    Task<WorkerBeneficiary> GetByWorkerId(Guid workerId);
    Task<WorkerBeneficiary> FindByWorkerId(Guid workerId);
    Task<List<WorkerBeneficiary>> GetAllBeneficiaries();
}