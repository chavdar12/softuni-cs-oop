using Ex003;

foreach (var bread in new Bread[] { new TwelveGrain(), new Sourdough(), new WholeWheat() })
{
    bread.Make();
    Console.WriteLine();
}
