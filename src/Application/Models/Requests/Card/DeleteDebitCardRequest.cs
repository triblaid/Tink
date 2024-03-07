namespace Project.Application;

public record DeleteDebitCardRequest
{
    public Guid BeneficiaryId { get; init; }
    public Guid BankDetailsId { get; init; }

    public DeleteDebitCardRequest(Guid beneficiaryId, Guid bankDetailsId)
    {
        BeneficiaryId = beneficiaryId;
        BankDetailsId = bankDetailsId;
    }
}
