namespace Project.Application;

public record UpdateIncomeWithdrawalStatus(Guid WithdrawalId, WithdrawalStatus Status, string Error) : ICommand;
public record UpdateDebitCardRequestStatus(Guid DebitCardId, DebitCardRegistrationStatus Status, Guid? bankDetailsId) : ICommand;

public record AssignIncomingTransaction(
    Guid TransactionId,
    string Tin,
    decimal Amount
    ) : ICommand;

public record VerifyWorkersFfmsStatuses() : ICommand;
public record VerifyWorkerFfmsStatus(Guid WorkerId) : ICommand;