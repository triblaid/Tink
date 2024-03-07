namespace Project.Application;

public interface ITinkoffService
{
    Task<CreateBeneficiaryResult> CreateBeneficiary<T>(T query) where T : CreateBeneficiaryRequest;
    Task<UpdateBeneficiaryWorkerResult> UpdateBeneficiaryWorker(UpdateBeneficiaryWorkerRequest request);
    Task<GetTinkoffBeneficiaryScoringPageResult> GetBeneficiaryScoring(GetBeneficiaryScoringRequest request);

    Task<CreateDebitCardRequestResult> CreateDebitCardRequest(Guid workerBeneficiaryId, Guid commandId);
    Task<GetDebitCardRequestResult> GetDebitCardRequest(Guid registrationRequestId, Guid beneficiaryId);
    Task<TinkoffRequestResult> DeleteDebitCardRequest(Guid beneficiaryId,Guid bankDetailsId);

    Task<CreateCompletedDealResult> CreateAndCompleteDeal(Guid jobPaymentId, decimal amount, Guid legalEntityBeneficiaryId,
        Guid workerBeneficiaryId, Guid jobApplicationId);

    Task<PaymentResult> CreatePayment(Guid bankDetailsId, Guid workerBeneficiaryId, Guid withdrawalId, decimal amount);
    Task<PaymentResult> GetPaymentById(Guid PaymentId);

    Task<IEnumerable<IncomingTransaction>> GetIncomingTransactions();
    Task<TinkoffRequestResult> IdentifyIncomingTransaction(Guid transactionId, Guid legalEntityBeneficiaryId, decimal amount);

    Task<string> CreateInvoice(LegalEntity legalEntity, int invoiceNumber, string legalEntityAgreementNumber, decimal amount);
}
