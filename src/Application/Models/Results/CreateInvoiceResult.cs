namespace Project.Application;

public record CreateInvoiceResult : TinkoffRequestResult
{
    public string PdfUrl { get; init; }
}