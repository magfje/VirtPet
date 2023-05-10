namespace VirtPet;

using static Console;

public class Menu
{
    private readonly List<FoodItem>? _optionList;
    private readonly List<Animal>? _optionListAnimals;
    private readonly string[] _options = null!;
    private readonly string _prompt;
    private int _selectedIndex;

    public Menu(string prompt, string[] options)
    {
        _options = options;
        _prompt = prompt;
        _selectedIndex = 0;
    }

    public Menu(string prompt, List<FoodItem>? optionList)
    {
        _optionList = optionList;
        _prompt = prompt;
        _selectedIndex = 0;
    }

    public Menu(string prompt, List<Animal>? optionListAnimals)
    {
        _optionListAnimals = optionListAnimals;
        _prompt = prompt;
        _selectedIndex = 0;
    }

    private void DisplayOptions()
    {
        CursorVisible = false;
        WriteLine(_prompt + "\n");
        for (var i = 0; i < _options.Length; i++)
        {
            var currentOption = _options[i];
            string prefix;

            if (i == _selectedIndex)
            {
                prefix = "👉";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Green;
            }
            else
            {
                prefix = "  ";
                ForegroundColor = ConsoleColor.Green;
                BackgroundColor = ConsoleColor.Black;
            }

            WriteLine($"{prefix} << {currentOption} >>");
        }

        ResetColor();
    }

    // ReSharper disable once UnusedParameter.Local
    private void DisplayOptions(string f)
    {
        CursorVisible = false;
        WriteLine(_prompt + "\n");
        if (_optionList != null)
            for (var i = 0; i < _optionList.Count; i++)
            {
                var currentOption = _optionList[i];
                string prefix;


                if (i == _selectedIndex)
                {
                    prefix = "👉";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = "  ";
                    ForegroundColor = ConsoleColor.Green;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption.Name} ({currentOption.Count}) >>");
            }

        ResetColor();
    }

    // ReSharper disable once UnusedParameter.Local
    private void DisplayOptions(int f)
    {
        CursorVisible = false;
        WriteLine(_prompt + "\n");
        for (var i = 0; i < _optionListAnimals!.Count; i++)
        {
            var currentOption = _optionListAnimals[i];
            string prefix;


            if (i == _selectedIndex)
            {
                prefix = "👉";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Green;
            }
            else
            {
                prefix = "  ";
                ForegroundColor = ConsoleColor.Green;
                BackgroundColor = ConsoleColor.Black;
            }

            WriteLine($"{prefix} << {currentOption.Name} | Level: {currentOption.Level} >>");
        }

        ResetColor();
    }

    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Clear();
            DisplayOptions();
            var keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            //update SelectedIndex based on arrow keys
            if (keyPressed == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex == -1) _selectedIndex = _options.Length - 1;
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex == _options.Length) _selectedIndex = 0;
            }
        } while (keyPressed != ConsoleKey.Enter);

        return _selectedIndex;
    }

    public int Run(string f)
    {
        ConsoleKey keyPressed;
        do
        {
            Clear();
            DisplayOptions(f);
            var keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            //update SelectedIndex based on arrow keys
            if (keyPressed == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex == -1) _selectedIndex = _optionList!.Count - 1;
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex == _optionList!.Count) _selectedIndex = 0;
            }
        } while (keyPressed != ConsoleKey.Enter);

        return _selectedIndex;
    }

    public int Run(int f)
    {
        ConsoleKey keyPressed;
        do
        {
            Clear();
            DisplayOptions(f);
            var keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            //update SelectedIndex based on arrow keys
            if (keyPressed == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex == -1) _selectedIndex = _optionListAnimals!.Count - 1;
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex == _optionListAnimals!.Count) _selectedIndex = 0;
            }
        } while (keyPressed != ConsoleKey.Enter);

        return _selectedIndex;
    }
}