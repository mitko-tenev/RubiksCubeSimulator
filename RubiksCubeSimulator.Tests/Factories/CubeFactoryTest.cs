using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Tests.Factories
{
    public class CubeFactoryTest
    {
        [Fact]
        public void CreateStandardCube()
        {
            var instance = CubeFactory.CreateStandardCube();

            Assert.IsAssignableFrom<ICube>(instance);
        }
    }
}
