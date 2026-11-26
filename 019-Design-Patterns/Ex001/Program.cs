using Ex001;

var db = SingletonDataContainer.Instance;
var db2 = SingletonDataContainer.Instance;
var db3 = SingletonDataContainer.Instance;
var db4 = SingletonDataContainer.Instance;

Console.WriteLine(db.GetPopulation("Tokyo"));
Console.WriteLine(db4.GetPopulation("Mexico City"));
