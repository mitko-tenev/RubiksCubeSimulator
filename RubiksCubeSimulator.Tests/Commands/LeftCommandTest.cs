using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Tests.Commands
{
    public class LeftCommandTest
    {
        private LeftCommand? _sut;

        [Theory]
        [MemberData(nameof(ClockwiseData))]
        public void Execute_Clockwise(CubeFace face, char[,] expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new LeftCommand((RubiksCube)cube, true);

            this._sut.Execute();

            Assert.Equal(expected, cube.GetFace(face));
        }

        public static IEnumerable<object[]> ClockwiseData =>
        new List<object[]>
        {
                        new object[] { CubeFace.Up, new char[3, 3]
                        {
                            { 'B', 'W', 'W' },
                            { 'B', 'W', 'W' },
                            { 'B', 'W', 'W' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'G', 'Y', 'Y' },
                            { 'G', 'Y', 'Y' },
                            { 'G', 'Y', 'Y' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'W', 'G', 'G' },
                            { 'W', 'G', 'G' },
                            { 'W', 'G', 'G' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'B', 'B', 'Y' },
                            { 'B', 'B', 'Y' },
                            { 'B', 'B', 'Y' }
                        } },
                        new object[] { CubeFace.Left, new char[3, 3]
                        {
                            { 'O', 'O', 'O' },
                            { 'O', 'O', 'O' },
                            { 'O', 'O', 'O' }
                        } }
                        ,
                        new object[] { CubeFace.Right, new char[3, 3]
                        {
                            { 'R', 'R', 'R' },
                            { 'R', 'R', 'R' },
                            { 'R', 'R', 'R' }
                        } }
        };


        [Theory]
        [MemberData(nameof(CounterClockwiseData))]
        public void Execute_CounterClockwise(CubeFace face, char[,] expected)
        {

            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new LeftCommand((RubiksCube)cube, false);

            this._sut.Execute();

            Assert.Equal(expected, cube.GetFace(face));
        }
        public static IEnumerable<object[]> CounterClockwiseData =>
         new List<object[]>
         {
                        new object[] { CubeFace.Up, new char[3, 3]
                        {
                            { 'G', 'W', 'W' },
                            { 'G', 'W', 'W' },
                            { 'G', 'W', 'W' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'B', 'Y', 'Y' },
                            { 'B', 'Y', 'Y' },
                            { 'B', 'Y', 'Y' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'Y', 'G', 'G' },
                            { 'Y', 'G', 'G' },
                            { 'Y', 'G', 'G' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'B', 'B', 'W' },
                            { 'B', 'B', 'W' },
                            { 'B', 'B', 'W' }
                        } },
                        new object[] { CubeFace.Left, new char[3, 3]
                        {
                            { 'O', 'O', 'O' },
                            { 'O', 'O', 'O' },
                            { 'O', 'O', 'O' }
                        } }
                        ,
                        new object[] { CubeFace.Right, new char[3, 3]
                        {
                            { 'R', 'R', 'R' },
                            { 'R', 'R', 'R' },
                            { 'R', 'R', 'R' }
                        } }
         };

        [Theory]
        [InlineData(true, "L")]
        [InlineData(false, "L'")]
        public void GetDescription(bool clockwise, string expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new LeftCommand((RubiksCube)cube, clockwise);

            string actual = _sut.GetDescription();

            Assert.Equal(expected, actual);
        }
    }
}
