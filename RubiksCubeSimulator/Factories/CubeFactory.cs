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
