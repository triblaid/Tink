namespace Project;

public record WorkerBeneficiary
{
    public Guid BeneficiaryId { get; set; }
    public Guid WorkerId { get; set; }
    public string Address { get; set; }

    private WorkerBeneficiary() { }

    public WorkerBeneficiary(Guid beneficiaryId, Guid workerId, string address)
    {
        if (beneficiaryId == Guid.Empty) throw new BehaviourException("BeneficiaryId can't be empty uuid.");
        if (workerId == Guid.Empty) throw new BehaviourException("WorkerId can't be empty uuid.");
        if (string.IsNullOrEmpty(address)) throw new BehaviourException("Address can't be empty or null.");

        BeneficiaryId = beneficiaryId;
        WorkerId = workerId;
        Address = address;
    }
}