namespace Project.Application;

public record TinkoffRequestResult
{
    public string RequestId { get; set; }
    public string RequestType { get; set; }
    public int StatusCode { get; set; }
    public string Error { get; set; }
    public bool IsSuccess => string.IsNullOrEmpty(Error);
}