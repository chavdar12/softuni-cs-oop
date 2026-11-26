using Ex001;

var chainblock = new Chainblock();
chainblock.Add(new Transaction(1, TransactionStatus.Successful, "john", "michel", 5));
chainblock.Add(new Transaction(2, TransactionStatus.Successful, "john", "anna", 6));
chainblock.Add(new Transaction(3, TransactionStatus.Aborted, "john", "anna", 7));
chainblock.Add(new Transaction(4, TransactionStatus.Successful, "michel", "john", 2));

Console.WriteLine(string.Join(", ", chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful)));
