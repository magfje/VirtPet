namespace VirtPet;

public class Animal
{
    public static string[] FoodStrings = { "Bread", "Beans", "Dried Meat", "Fish", "Bugs" };

    internal readonly string[] EncounterStrings =
        { "Ferocious beast", "Scared animal", "Joyous Cutie", "Curious thing" };

    public Animal()
    {
        Name = EncounterStrings[new Random().Next(0, EncounterStrings.Length)];
        Level = new Random().Next(1, 11);
        FavoriteFood = FoodStrings[new Random().Next(0, FoodStrings.Length)];
        Abilities = new List<Ability> { new(), new() };
    }

    public Animal(string name)
    {
        Name = name;
        Level = new Random().Next(1, 11);
        FavoriteFood = FoodStrings[new Random().Next(0, FoodStrings.Length)];
        Abilities = new List<Ability> { new(), new() };
    }

    public string Name { get; private set; }
    public int Level { get; }
    public string FavoriteFood { get; }

    public List<Ability> Abilities { get; }

    public void GiveName()
    {
        Console.CursorVisible = true;
        while (true)
        {
            Console.WriteLine("Give your new pet a name!");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
                Console.CursorVisible = false;
                return;
            }


            Console.WriteLine($"'{name}' is not a valid name");
        }
    }

    public string ShowStats()
    {
        var stats = @$"Name: {Name}
Level: {Level}
Favorite food: {FavoriteFood}
Abilities:
";
        foreach (var a in Abilities) Console.WriteLine(stats += $"   {a.AbilityName} | DMG: {a.Damage}\n");
        stats += $"\nWould you like to feed {Name}?";
        return stats;
    }
}