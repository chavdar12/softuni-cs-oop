using Ex002;

var phone = new SingleGift("Phone", 256);
phone.CalculateTotalPrice();
Console.WriteLine();

var rootBox = new CompositeGift("RootBox", 0);
rootBox.Add(new SingleGift("TruckToy", 289));
rootBox.Add(new SingleGift("PlainToy", 587));

var childBox = new CompositeGift("ChildBox", 0);
childBox.Add(new SingleGift("SoldierToy", 200));
rootBox.Add(childBox);

Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
