namespace Project.Application;

public interface IWorkerService : IService
{
    Task<Worker> GetById(Guid id);
}
