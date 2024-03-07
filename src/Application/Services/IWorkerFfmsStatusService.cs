namespace Project.Application;

public interface IWorkerFfmsStatusService : IService
{
    Task CheckWorkerFfmsStatus(Guid beneficiaryId, Guid workerId, GetTinkoffBeneficiaryScoringPageResult response);
}
