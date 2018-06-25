using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleIdentifier
{
  public class ConsoleTriangleIdentifier : IConsoleTriangleIdentifier
  {
    private ITriangleIdentifier identifier;

    public ConsoleTriangleIdentifier(ITriangleIdentifier identifier)
    {
      this.identifier = identifier;
    }

    public void Run()
    {
      while (true)
      {
        Console.WriteLine("Enter side {0}:", identifier.SideCount + 1);
        string input = Console.ReadLine();

        if (input == "exit")
        {
          break;
        }

        if (int.TryParse(input, out int side))
        {
          string result = identifier.AddSide(side);
          if (result != "") Console.WriteLine(result);
        }
        else
        {
          Console.WriteLine("You did not enter a valid value");
        }
      }
    }
  }
}
