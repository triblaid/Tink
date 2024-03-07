namespace Project;

public class WorkerFfmsStatus : EventEmitter<WorkerFfmsStatusStream>
{
    protected override Guid StreamId => WorkerId;

    public Guid WorkerId { get; private set; }
    public bool? IsBlacklisted { get; private set; }

    private WorkerFfmsStatus() { }

    public WorkerFfmsStatus(Guid workerId, bool? isBlacklisted)
    {
        WorkerId = workerId;
        IsBlacklisted = isBlacklisted;

        if (isBlacklisted.HasValue)
            EmitChange(new WorkerFfmsStatusChanged(isBlacklisted.Value));
    }

    public void Change(bool? isBlacklisted)
    {
        if (IsBlacklisted == isBlacklisted) return;

        IsBlacklisted = isBlacklisted;

        if (isBlacklisted.HasValue)
            EmitChange(new WorkerFfmsStatusChanged(isBlacklisted.Value));
    }
}
