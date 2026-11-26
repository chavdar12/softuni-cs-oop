using Ex001;

namespace Ex001Tests;

[TestFixture]
public class ChainblockTests
{
    [SetUp]
    public void Setup()
    {
        chainblock = new Chainblock();
        first = new Transaction(1, TransactionStatus.Successful, "john", "michel", 5);
        second = new Transaction(2, TransactionStatus.Successful, "john", "anna", 6);
        third = new Transaction(3, TransactionStatus.Aborted, "john", "anna", 7);
        fourth = new Transaction(4, TransactionStatus.Successful, "michel", "anna", 6);
        foreach (var transaction in new[] { first, second, third, fourth })
            chainblock.Add(transaction);
    }

    private Chainblock chainblock;
    private Transaction first;
    private Transaction second;
    private Transaction third;
    private Transaction fourth;

    [Test]
    public void AddIncreasesCount()
    {
        Assert.That(chainblock.Count, Is.EqualTo(4));
    }

    [Test]
    public void AddThrowsForDuplicateId()
    {
        Assert.Throws<InvalidOperationException>(() =>
            chainblock.Add(new Transaction(1, TransactionStatus.Failed, "a", "b", 1))
        );
    }

    [Test]
    public void ContainsMatchesById()
    {
        Assert.That(chainblock.Contains(new Transaction(1, TransactionStatus.Failed, "x", "y", 0)), Is.True);
        Assert.That(chainblock.Contains(1), Is.True);
        Assert.That(chainblock.Contains(99), Is.False);
    }

    [Test]
    public void ChangeTransactionStatusUpdatesStatus()
    {
        chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);
        Assert.That(first.Status, Is.EqualTo(TransactionStatus.Failed));
    }

    [Test]
    public void ChangeTransactionStatusThrowsForMissingId()
    {
        Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(99, TransactionStatus.Failed));
    }

    [Test]
    public void RemoveTransactionByIdRemovesIt()
    {
        chainblock.RemoveTransactionById(2);

        Assert.That(chainblock.Contains(2), Is.False);
        Assert.That(chainblock, Is.EqualTo(new[] { first, third, fourth }));
    }

    [Test]
    public void RemoveTransactionByIdThrowsForMissingId()
    {
        Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(99));
    }

    [Test]
    public void GetByIdReturnsTransactionOrThrows()
    {
        Assert.That(chainblock.GetById(3), Is.SameAs(third));
        Assert.Throws<InvalidOperationException>(() => chainblock.GetById(99));
    }

    [Test]
    public void GetByTransactionStatusOrdersByAmountDescending()
    {
        Assert.That(
            chainblock.GetByTransactionStatus(TransactionStatus.Successful),
            Is.EqualTo(new[] { second, fourth, first })
        );
        Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized)
        );
    }

    [Test]
    public void GetAllSendersWithTransactionStatusKeepsDuplicates()
    {
        Assert.That(
            chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful),
            Is.EqualTo(new[] { "john", "michel", "john" })
        );
        Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed)
        );
    }

    [Test]
    public void GetAllReceiversWithTransactionStatusKeepsDuplicates()
    {
        Assert.That(
            chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful),
            Is.EqualTo(new[] { "anna", "anna", "michel" })
        );
        Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed)
        );
    }

    [Test]
    public void GetAllOrderedByAmountDescendingThenById()
    {
        Assert.That(
            chainblock.GetAllOrderedByAmountDescendingThenById(),
            Is.EqualTo(new[] { third, second, fourth, first })
        );
    }

    [Test]
    public void GetBySenderOrderedByAmountDescending()
    {
        Assert.That(
            chainblock.GetBySenderOrderedByAmountDescending("john"),
            Is.EqualTo(new[] { third, second, first })
        );
        Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("anna"));
    }

    [Test]
    public void GetByReceiverOrderedByAmountThenById()
    {
        Assert.That(
            chainblock.GetByReceiverOrderedByAmountThenById("anna"),
            Is.EqualTo(new[] { third, second, fourth })
        );
        Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("john"));
    }

    [Test]
    public void GetByTransactionStatusAndMaximumAmountIsInclusive()
    {
        Assert.That(
            chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successful, 5),
            Is.EqualTo(new[] { first })
        );
        Assert.That(chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 100), Is.Empty);
    }

    [Test]
    public void GetBySenderAndMinimumAmountDescendingIsExclusive()
    {
        Assert.That(chainblock.GetBySenderAndMinimumAmountDescending("john", 5), Is.EqualTo(new[] { third, second }));
        Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("john", 7));
    }

    [Test]
    public void GetByReceiverAndAmountRangeIncludesLowExcludesHigh()
    {
        Assert.That(chainblock.GetByReceiverAndAmountRange("anna", 6, 7), Is.EqualTo(new[] { second, fourth }));
        Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("anna", 1, 6));
    }

    [Test]
    public void GetAllInAmountRangeIsInclusiveInInsertionOrder()
    {
        Assert.That(chainblock.GetAllInAmountRange(5, 6), Is.EqualTo(new[] { first, second, fourth }));
        Assert.That(chainblock.GetAllInAmountRange(100, 200), Is.Empty);
    }
}
