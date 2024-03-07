namespace Project.Application;

public partial class BeneficiaryCommandHandler : ICommandHandler<CreateLegalEntityBeneficiary>
{
    public async Task Handle(CommandArgs<CreateLegalEntityBeneficiary> args)
    {
        var legalEntityId = args.Payload.LegalEntityId;

        var legalEntity = await _legalEntityService.GetById(legalEntityId);
        var beneficiary = await _tinkoffService.CreateBeneficiary(new CreateBeneficiaryLegalEntityRequest(legalEntity));

        _logger.LogInformation("Processing {handlerName} with email = {email}", nameof(CreateLegalEntityBeneficiary), legalEntity.Email);

        if (!beneficiary.IsSuccess)
        {
            var createTechnicalIssue = new CreateTechnicalIssue(TechnicalIssuesType.WorkerBeneficiaryCreation, beneficiary.Error, args.Payload.ToJsonElement());
            _messages.Add(createTechnicalIssue);
        }

        var legalEntityBeneficiary = new LegalEntityBeneficiary(beneficiary.BeneficiaryId, legalEntity.Id, legalEntity.Tin);
        _legalEntityBeneficiaryRepository.Add(legalEntityBeneficiary);
    }
}