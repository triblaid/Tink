namespace Project.Application;

public class GetDebitCardRequestQuery : IBeneficiary
{
    public GetDebitCardRequestQuery(Guid registrationRequestId, Guid beneficiaryId)
    {
        AddCardRequestId = registrationRequestId;
        BeneficiaryId = beneficiaryId;
    }

    public Guid AddCardRequestId { get; init; }
    public Guid BeneficiaryId { get; init; }
}