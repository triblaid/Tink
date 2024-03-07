namespace Project.Application;

public interface IWorkerFfmsStatusRepository : IRepository<WorkerFfmsStatus>
{
    Task<WorkerFfmsStatus> Get(Guid workerId);
    Task<List<WorkerFfmsStatus>> GetAllWithoutStatus();
}