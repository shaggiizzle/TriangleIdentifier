using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleIdentifier
{
  public class Program
  {
    public static void Main(string[] args)
    {
      ITriangleIdentifier triangleIdentifier = new TriangleIdentifier();
      IConsoleTriangleIdentifier consoleIdentifier = new ConsoleTriangleIdentifier(triangleIdentifier);
      consoleIdentifier.Run();
    }

  }

 
}
