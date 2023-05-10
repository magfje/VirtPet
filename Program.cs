using System.Text;

namespace VirtPet;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        new Game().Start();
    }
}