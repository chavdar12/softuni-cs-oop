using System.Collections;

namespace Ex001;

public class Chainblock : IChainblock
{
    // Dictionary for O(1) id lookups, list to keep insertion order.
    private readonly Dictionary<int, Transaction> byId = new();
    private readonly List<Transaction> transactions = new();

    public int Count => transactions.Count;

    public void Add(Transaction transaction)
    {
        if (!byId.TryAdd(transaction.Id, transaction))
            throw new InvalidOperationException($"Transaction {transaction.Id} already exists.");

        transactions.Add(transaction);
    }

    public bool Contains(Transaction transaction) => Contains(transaction.Id);

    public bool Contains(int id) => byId.ContainsKey(id);

    public void ChangeTransactionStatus(int id, TransactionStatus status)
    {
        if (!byId.TryGetValue(id, out var transaction))
            throw new ArgumentException($"Transaction {id} does not exist.");

        transaction.Status = status;
    }

    public void RemoveTransactionById(int id)
    {
        transactions.Remove(GetById(id));
        byId.Remove(id);
    }

    public Transaction GetById(int id)
    {
        return byId.TryGetValue(id, out var transaction)
            ? transaction
            : throw new InvalidOperationException($"Transaction {id} does not exist.");
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        return NotEmpty(transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount));
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        return GetByTransactionStatus(status).Select(t => t.From);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        return GetByTransactionStatus(status).Select(t => t.To);
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        return NotEmpty(transactions.Where(t => t.From == sender).OrderByDescending(t => t.Amount));
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        return NotEmpty(transactions.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id));
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        return transactions.Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(t => t.Amount);
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        return NotEmpty(
            transactions.Where(t => t.From == sender && t.Amount > amount).OrderByDescending(t => t.Amount)
        );
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        return NotEmpty(
            transactions
                .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
        );
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        return transactions.Where(t => t.Amount >= lo && t.Amount <= hi);
    }

    public IEnumerator<Transaction> GetEnumerator() => transactions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private static List<T> NotEmpty<T>(IEnumerable<T> items)
    {
        var list = items.ToList();

        return list.Count > 0 ? list : throw new InvalidOperationException("No matching transactions.");
    }
}
