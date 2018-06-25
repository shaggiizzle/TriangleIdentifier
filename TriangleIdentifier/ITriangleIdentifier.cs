﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleIdentifier
{
  public interface ITriangleIdentifier
  {
    int SideCount { get; }
    string AddSide(int side);
  }
}
