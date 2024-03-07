namespace Project.Application;

public partial class TinkoffQueryHandler : IQueryHandler<GetDebitCardRegistrationUrl, string>
{
    public async Task<string> Handle(QueryArgs<GetDebitCardRegistrationUrl> args)
    {
        var tinkoffDebitCard = await _debitCardRepository.GetById(args.Payload.DebitCardId);
        return tinkoffDebitCard.RegistrationUrl;
    }
}