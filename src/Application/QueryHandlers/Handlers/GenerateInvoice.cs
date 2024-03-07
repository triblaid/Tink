namespace Project.Application;

public partial class TinkoffQueryHandler : IQueryHandler<GenerateInvoice, string>
{
    public async Task<string> Handle(QueryArgs<GenerateInvoice> args)
    {
        var payload = args.Payload;

        var legalEntity = await _legalEntityService.GetById(payload.LegalEntityId);
        var legalEntityAgreementNumber = await _legalEntityAgreementRepository.GetLegalEntityAgreementNumber(payload.LegalEntityId);

        var invoiceNumber = await _counterClient.GetNextValue($"legal-entity/{payload.LegalEntityId}/invoice");        

        var result = await _tinkoffService.CreateInvoice(legalEntity, invoiceNumber, legalEntityAgreementNumber, payload.Amount);

        return result;
    }
}