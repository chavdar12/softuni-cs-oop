namespace Ex001;

public class Transaction
{
    public Transaction(int id, TransactionStatus status, string from, string to, double amount)
    {
        Id = id;
        Status = status;
        From = from;
        To = to;
        Amount = amount;
    }

    public int Id { get; }

    public TransactionStatus Status { get; set; }

    public string From { get; }

    public string To { get; }

    public double Amount { get; }
}
