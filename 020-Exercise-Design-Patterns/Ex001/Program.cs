using Ex001;

var menu = new SandwichMenu
{
    ["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato"),
    ["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly"),
    ["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato"),
    ["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives"),
    ["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion"),
    ["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach"),
};

var sandwich1 = (Sandwich)menu["BLT"].Clone();
var sandwich2 = (Sandwich)menu["ThreeMeatCombo"].Clone();
var sandwich3 = (Sandwich)menu["Vegetarian"].Clone();
