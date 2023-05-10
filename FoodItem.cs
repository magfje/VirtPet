namespace VirtPet;

public class FoodItem
{
    public FoodItem(string name)
    {
        Name = name;
        Count = 1;
    }

    public string Name { get; set; }
    public int Count { get; set; }
}