namespace Project.Application;

public record CreateCompletedDealResult : TinkoffRequestResult
{
    public Guid DealId { get; set; }
    public Guid DealStepId { get; set; }
    public string DealStepRequestId { get; set; }
    public string DeponentRequestId { get; set; }
    public string RecipientRequestId { get; set; }
    public string AcceptRequestId { get; set; }
    public string CompleteRequestId { get; set; }

    public void SetParams<TRequest>(CreateCompletedDealResult result, TRequest tinkoffResponse) where TRequest : TinkoffRequestResult
    {
        result.StatusCode = tinkoffResponse.StatusCode;
        result.Error = tinkoffResponse.Error;
        result.RequestType = tinkoffResponse.RequestType;

        if (tinkoffResponse is CreateDealResult deal)
        {
            result.DealId = deal.DealId;
            result.RequestId = tinkoffResponse.RequestId;
            return;
        }

        if (tinkoffResponse is CreateDealStepResult dealStep)
        {
            result.DealStepId = dealStep.StepId;
            result.DealStepRequestId = tinkoffResponse.RequestId;
            return;
        }

        if (string.IsNullOrEmpty(result.DeponentRequestId))
        {
            result.DeponentRequestId = tinkoffResponse.RequestId;
            return;
        }

        if (string.IsNullOrEmpty(result.RecipientRequestId))
        {
            result.RecipientRequestId = tinkoffResponse.RequestId;
            return;
        }

        if (string.IsNullOrEmpty(result.AcceptRequestId))
        {
            result.AcceptRequestId = tinkoffResponse.RequestId;
            return;
        }

        result.CompleteRequestId = tinkoffResponse.RequestId;
    }
}