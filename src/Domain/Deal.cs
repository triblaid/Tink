using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Application;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project;

public record Deal
{
    public Guid JobPaymentId { get; set; }
    public Guid DeponentBeneficiaryId { get; set; }
    public Guid RecipientBeneficiaryId { get; set; }
    public decimal Amount { get; set; }
    [Column(TypeName = "jsonb")]
    public DealLog Log { get; set; }

    private Deal() { }
    public Deal(Guid jobPaymentId, decimal amount, CreateCompletedDealResult dealResult, LegalEntityBeneficiary legalEntityBeneficiary, WorkerBeneficiary workerBeneficiary)
    {
        if (jobPaymentId == Guid.Empty) throw new BehaviourException("jobPaymentId can't be empty uuid");
        if (legalEntityBeneficiary is null) throw new BehaviourException("legalEntityBeneficiary can't be null");
        if (workerBeneficiary is null) throw new BehaviourException("workerBeneficiary can't be null");
        if (dealResult is null) throw new BehaviourException("dealResult can't be null");
        if (amount <= 0) throw new BehaviourException("amount can't be less than 0");

        JobPaymentId = jobPaymentId;
        DeponentBeneficiaryId = legalEntityBeneficiary.BeneficiaryId;
        RecipientBeneficiaryId = workerBeneficiary.BeneficiaryId;
        Amount = amount;

        if (dealResult.DealId == Guid.Empty) throw new BehaviourException("DealId can't be empty uuid");
        if (dealResult.DealStepId == Guid.Empty) throw new BehaviourException("DealStepId can't be empty uuid");
        Log = new DealLog
        {
            DealId = dealResult.DealId,
            DealStepId = dealResult.DealStepId,
            DealRequestId = dealResult.RequestId,
            DealStepRequestId = dealResult.DealStepRequestId,
            DeponentRequestId = dealResult.DeponentRequestId,
            RecipientRequestId = dealResult.RecipientRequestId,
            AcceptRequestId = dealResult.AcceptRequestId,
            CompleteRequestId = dealResult.CompleteRequestId,
        };
    }
}

public record DealLog
{
    public Guid DealId { get; init; }
    public Guid DealStepId { get; init; }
    public string DealRequestId { get; init; }
    public string DealStepRequestId { get; init; }
    public string DeponentRequestId { get; init; }
    public string RecipientRequestId { get; init; }
    public string AcceptRequestId { get; init; }
    public string CompleteRequestId { get; init; }
}
