using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleIdentifier
{
  public class TriangleIdentifier : ITriangleIdentifier
  {
    private List<int> sides;

    public TriangleIdentifier()
    {
      sides = new List<int>();
    }

    public int SideCount => sides.Count;

    public string AddSide(int side)
    {
      string result = "";
      sides.Add(side);
      if (sides.Count == 3)
      {

        result = (Classify(sides[0], sides[1], sides[2]));
        sides.Clear();
      }
      return result;
    }

    private string Classify(int side1, int side2, int side3)
    {
      if (side1 == side2 && side2 == side3)
      {
        return "Equilateral";
      }
      if (side1 == side2 || side1 == side3)
      {
        return "Isosceles";
      }
      return "Scalene";
    }
  }
}
