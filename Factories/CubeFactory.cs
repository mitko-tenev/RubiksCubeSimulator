using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Factories
{
    public static class CubeFactory
    {
        public static ICube CreateStandardCube()
        {
            return new RubiksCube();
        }
    }
}
