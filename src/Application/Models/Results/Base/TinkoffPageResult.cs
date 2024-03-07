namespace Project.Application;

public record TinkoffPageResult : TinkoffRequestResult
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Size { get; set; }
    public int Total { get; set; }
}