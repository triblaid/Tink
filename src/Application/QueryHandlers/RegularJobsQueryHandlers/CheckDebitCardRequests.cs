namespace Project.Application;

public partial class TinkoffQueryHandler : IQueryHandler<CheckDebitCardRequests, bool>
{
    public async Task<bool> Handle(QueryArgs<CheckDebitCardRequests> args)
    {
        var debitCards = await _debitCardRepository.GetByStatusPending();
        foreach (var debitCard in debitCards)
        {
            var debitCardRequest = await _tinkoffService.GetDebitCardRequest(debitCard.RegistrationRequestId, debitCard.BeneficiaryId);

            if (debitCardRequest.Status != DebitCardRegistrationStatus.Pending)
                UpdateDebitCardRequestStatus(debitCard.DebitCardId, debitCardRequest);
        }

        return true;
    }

    private async void UpdateDebitCardRequestStatus(Guid debitCardId, GetDebitCardRequestResult debitCardRequest)
    {
        var processDebitCardRequestCommand = new UpdateDebitCardRequestStatus(debitCardId, debitCardRequest.Status, debitCardRequest.BankDetailsId);
        var response = await _rpcClient.Send(processDebitCardRequestCommand);

        if (response.Status != RpcStatus.Ok)
            _logger.LogWarning("Error occurred while updating debit card = {id}. Error: {error}", debitCardId, response.Message);
    }
}