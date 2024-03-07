namespace Project.Application;

public class LegalEntityAgreementEventHandler : IEventHandler<LegalEntityDocumentsSubmitted>
{
    private readonly ILegalEntityAgreementRepository _legalEntityAgreementRepository;

    public LegalEntityAgreementEventHandler(ILegalEntityAgreementRepository legalEntityAgreementRepository)
    {
        _legalEntityAgreementRepository = legalEntityAgreementRepository;
    }

    public async Task Handle(EventArgs<LegalEntityDocumentsSubmitted> args)
    {
        var payload = args.Payload;

        var legalEntityAgreement = await _legalEntityAgreementRepository.FindByIdLegalEntityId(payload.LegalEntityId);

        if (legalEntityAgreement is null)
            _legalEntityAgreementRepository.Add(new LegalEntityAgreement(args.StreamId, payload.LegalEntityId));
        else
            legalEntityAgreement.AgreementId = args.StreamId;
    }
}
