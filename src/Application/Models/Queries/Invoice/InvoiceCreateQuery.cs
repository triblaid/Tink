namespace Project.Application;

public class InvoiceCreateQuery
{
    public InvoiceCreateQuery(LegalEntity legalEntity, int invoiceNumber, string legalEntityAgreementNumber, decimal amount, string email, string accountNumber)
    {
        Payer = new Payer { Inn = legalEntity.Tin, Kpp = legalEntity.Trrc, Name = legalEntity.Name };
        Contacts = new List<Contact> { new Contact(email) };
        AccountNumber = accountNumber;
        DueDate = DateTime.UtcNow.AddDays(10).ToString("yyyy-MM-dd");
        InvoiceNumber = $"{legalEntity.Number}{invoiceNumber}"; // TODO: format number adding zeros
        Items = new List<Item>()
            {
                new Item
                {
                    Name = $"Перечисление средств для выполнения услуг в соответствии с Договором № {legalEntityAgreementNumber}",
                    Price = (double)amount,
                    Unit = "шт",
                    Vat = "None",
                    Amount = 1
                }
            };
    }

    public string InvoiceNumber { get; init; }
    public string DueDate { get; init; }
    public string AccountNumber { get; init; }
    public Payer Payer { get; init; }
    public List<Item> Items { get; init; }
    //Emails
    public List<Contact> Contacts { get; init; }
}

public record Payer
{
    public string Name { get; init; }
    public string Inn { get; init; }
    public string Kpp { get; init; }
}

public record Item
{
    public string Name { get; init; }
    public double Price { get; init; }
    public string Unit { get; init; }
    public string Vat { get; init; }
    public int Amount { get; init; }
}

public record Contact
{
    public string Email { get; init; }

    public Contact(string email)
    {
        Email = email;
    }
}