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
