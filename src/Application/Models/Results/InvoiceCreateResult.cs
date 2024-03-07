namespace Project.Application;

public record InvoiceCreateResult : TinkoffRequestResult
{
    public string PdfUrl { get; init; }
}