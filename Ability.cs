namespace VirtPet;

public class Ability
{
    private readonly string[] _abilitiesStrings = { "Slash", "Chop", "Cleave", "Thunder Blast" };

    public Ability()
    {
        AbilityName = _abilitiesStrings[new Random().Next(0, _abilitiesStrings.Length)];
        Damage = new Random().Next(1, 20);
    }

    public string AbilityName { get; set; }
    public int Damage { get; set; }
}