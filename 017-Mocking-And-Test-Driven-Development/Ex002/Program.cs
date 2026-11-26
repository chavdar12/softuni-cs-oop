using Ex002;

var hero = new Hero("Pesho", new Axe(10, 10));
hero.Attack(new Dummy(10, 20));
Console.WriteLine($"{hero.Name} has {hero.Experience} XP");
