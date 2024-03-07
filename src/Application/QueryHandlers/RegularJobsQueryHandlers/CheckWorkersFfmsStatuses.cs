namespace Project.Application;

public partial class TinkoffQueryHandler : IQueryHandler<CheckWorkersFfmsStatuses, bool>
{
    public async Task<bool> Handle(QueryArgs<CheckWorkersFfmsStatuses> args)
    {
        var workersFfmsStatuses = await _workerFfmsStatusRepository.GetAllWithoutStatus();

        if (!workersFfmsStatuses.Any()) return true;

        foreach (var status in workersFfmsStatuses)
        {
            var response = await _rpcClient.Send(new VerifyWorkerFfmsStatus(status.WorkerId));

            if (response.Status != RpcStatus.Ok)
                _logger.LogWarning("Error occurred while updating ffms status of worker = {id}. Error: {error}", 
                    status.WorkerId, response.Message);
        }

        return true;
    }
}