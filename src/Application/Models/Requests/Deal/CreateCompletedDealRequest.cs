namespace Project.Application;

public class CreateCompletedDealRequest : IIdempotency
{
    public CreateCompletedDealRequest(Guid jobPaymentId, decimal amount, Guid legalEntityBeneficiaryId, Guid workerBeneficiaryId, Guid jobApplicationId)
    {
        IdempotencyKey = jobPaymentId;
        Amount = amount;
        LegalEntityBeneficiaryId = legalEntityBeneficiaryId;
        WorkerBeneficiaryId = workerBeneficiaryId;
        JobApplicationId = jobApplicationId;
    }

    public Guid IdempotencyKey { get; init; }
    public decimal Amount { get; init; }
    public Guid JobApplicationId { get; init; }
    public Guid LegalEntityBeneficiaryId { get; init; }
    public Guid WorkerBeneficiaryId { get; init; }
}
