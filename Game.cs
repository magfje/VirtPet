namespace VirtPet;

using static Console;

public class Game
{
    public List<FoodItem>? FoodItems = new();
    public List<Animal>? PetsList = new();


    public void Start()
    {
        Title = "Adventure Simulator 3000!";
        RunMainMenu();
    }

    private void RunMainMenu()
    {
        var run = true;
        while (run)
        {
            var prompt = "Welcome to the adventure sim. What would you like to do?";
            string[] options = { "Go on a adventure", "Open pet list", "Open inventory", "Exit game" };
            var selectedIndex = new Menu(prompt, options).Run();

            switch (selectedIndex)
            {
                case 0:
                    StartAdventure();
                    break;
                case 1:
                    SomePetMethod();
                    break;
                case 2:
                    FoodList();
                    break;
                case 3:
                    run = false;
                    break;
            }
        }
    }

    private void StartAdventure()
    {
        var randNo1 = new Random().Next(0, 2);
        var randNo2 = new Random().Next(1, 3);
        RandomWait(2);
        if (randNo1 == 1) LootEncounter();
        RandomWait(2);
        if (randNo2 == 1) AnimalEncounter();
        Clear();
        WriteLine("Your adventure has ended!");
        PauseGame();
    }

    private static void RandomWait(int ttr)
    {
        for (var t = 0; t < ttr; t++)
        {
            Clear();
            string[] adventureString =
            {
                "🗻Climbing epic mountains🗻", "🤽Crossing giant rivers🤽", "🌳🌴Traversing dense forests🌴🌳",
                "🌋 Exploring active volcanoes 🌋", "🏜️ Hiking through rugged deserts 🏜️",
                "🚣‍♀Paddling wild rapids 🚣‍♀️"
            };
            string[] loadChars = { "|", "/", "-", "\\" };

            var stringToUse = adventureString[new Random().Next(0, adventureString.Length)];
            var p = 0;
            for (var i = 0; i < loadChars.Length * 3; i++)
            {
                Clear();
                WriteLine(stringToUse);
                WriteLine("     " + loadChars[p] + "\r");
                Thread.Sleep(200);
                p++;
                if (p == loadChars.Length) p = 0;
            }
        }
    }

    public void AnimalEncounter()
    {
        var encounteredAnimal = new Animal();
        var prompt = @$"
-- You stumbled upon a {encounteredAnimal.Name}!! --

Would you like to give it some food?";
        string[] options = { "Yes", "No" };
        var selectedIndex = new Menu(prompt, options).Run();
        switch (selectedIndex)
        {
            case 0:
                if (FoodItems!.Count > 0)
                {
                    FeedAnimal(encounteredAnimal);
                    AddPet(encounteredAnimal);
                }
                else
                {
                    Clear();
                    WriteLine("You have no food in your inventory, you should probably run!💀");
                    PauseGame();
                }

                break;
            case 1:
                PauseGame();
                break;
        }
    }

    public void LootEncounter()
    {
        string[] locationStrings = { "abandoned hut", "crusty shed", "empty castle" };
        var encounterLocation = locationStrings[new Random().Next(0, locationStrings.Length)];
        var lootName = Animal.FoodStrings[new Random().Next(0, Animal.FoodStrings.Length)];
        var encounteredLoot = new FoodItem(lootName);
        var prompt = @$"
-- You stumbled upon a {encounterLocation}! --

Would you like to search for loot?";
        string[] options = { "Yes", "No" };
        var selectedIndex = new Menu(prompt, options).Run();
        switch (selectedIndex)
        {
            case 0:
                StartLoot(encounteredLoot);
                break;
            case 1:
                PauseGame();
                break;
        }
    }

    private void StartLoot(FoodItem loot)
    {
        var containsItem = FoodItems!.Any(x => x.Name == loot.Name);
        if (!containsItem)
        {
            FoodItems!.Add(loot);
        }
        else
        {
            var existingItem = FoodItems!.Find(x => x.Name == loot.Name);
            existingItem!.Count++;
        }

        Clear();
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"\n-- You found \"{loot.Name}\" and added it to you inventory! --");
        ForegroundColor = ConsoleColor.DarkRed;
        PauseGame();
    }

    private void FeedAnimal(Animal toFeedAnimal)
    {
        var foodIndex = FoodList();
        var foodToFeed = FoodItems?[foodIndex];

        if (foodToFeed!.Count > 1) foodToFeed.Count--;
        else FoodItems?.RemoveAt(foodIndex);
        Clear();
        WriteLine(toFeedAnimal.FavoriteFood == foodToFeed.Name
            ? $"{toFeedAnimal.Name}:OMG! {foodToFeed.Name} is my favorite!"
            : $"{toFeedAnimal.Name}:Thanks for the {foodToFeed.Name}!");
        PauseGame();
    }

    private int FoodList()
    {
        Clear();
        if (FoodItems!.Count == 0)
        {
            WriteLine("You have no food in your inventory, explore some more to gather food!");
            PauseGame();

            return -1;
        }

        var prompt = "This is the food in your inventory:";
        var options = FoodItems;
        var selectedIndex = new Menu(prompt, options).Run("f");
        return selectedIndex;
    }

    private void AddPet(Animal toAddAnimal)
    {
        Clear();
        WriteLine($"A {toAddAnimal.Name} wants to be your pet");
        toAddAnimal.GiveName();
        PetsList!.Add(toAddAnimal);
        Clear();
        WriteLine($"{toAddAnimal.Name} was added to your inventory!");
        PauseGame();
    }

    private static void PauseGame()
    {
        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("\n\nPress any key to continue");
        ReadKey(true);
        ResetColor();
    }

    private int PetList()
    {
        Clear();

        var prompt = "Select a pet to show more stats";
        var options = PetsList;
        var selectedIndex = new Menu(prompt, options).Run(1);
        return selectedIndex;
    }

    private void SomePetMethod()
    {
        Clear();
        if (PetsList!.Count < 1)
        {
            WriteLine("You have no pets in your inventory, go on an adventure to find one!");
            PauseGame();
        }
        else
        {
            var index = PetList();
            var toFeed = PetsList[index];
            toFeed.ShowStats();

            var prompt = toFeed.ShowStats();
            string[] options = { "Yes", "No" };
            var selectedIndex = new Menu(prompt, options).Run();

            switch (selectedIndex)
            {
                case 0:
                    FeedAnimal(toFeed);
                    //PauseGame();
                    break;
                case 1:
                    break;
            }
        }
    }
}