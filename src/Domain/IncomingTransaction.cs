namespace Project;

public record IncomingTransaction
{
    public Guid Id { get; set; }
    public string Tin { get; set; }
    public decimal Amount { get; set; }

    public IncomingTransaction(Guid id, string tin, decimal amount)
    {
        if (id == Guid.Empty) throw new BehaviourException("id can't be empty uuid");
        if (string.IsNullOrWhiteSpace(tin)) throw new BehaviourException("tin can't be empty string");
        if (amount <= 0) throw new BehaviourException("amount can't be less than 0");

        Id = id;
        Tin = tin;
        Amount = amount;
    }
}