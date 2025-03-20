using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Tests.Commands
{
    public class RightCommandTest
    {
        private RightCommand? _sut;

        [Theory]
        [MemberData(nameof(ClockwiseData))]
        public void Execute_Clockwise(CubeFace face, char[,] expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new RightCommand((RubiksCube)cube, true);

            this._sut.Execute();

            Assert.Equal(expected, cube.GetFace(face));
        }

        public static IEnumerable<object[]> ClockwiseData =>
        new List<object[]>
        {
                        new object[] { CubeFace.Up, new char[3, 3]
                        {
                            { 'W', 'W', 'G' },
                            { 'W', 'W', 'G' },
                            { 'W', 'W', 'G' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'Y', 'Y', 'B' },
                            { 'Y', 'Y', 'B' },
                            { 'Y', 'Y', 'B' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'G', 'G', 'Y' },
                            { 'G', 'G', 'Y' },
                            { 'G', 'G', 'Y' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'W', 'B', 'B' },
                            { 'W', 'B', 'B' },
                            { 'W', 'B', 'B' }
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

            this._sut = new RightCommand((RubiksCube)cube, false);

            this._sut.Execute();

            Assert.Equal(expected, cube.GetFace(face));
        }
        public static IEnumerable<object[]> CounterClockwiseData =>
         new List<object[]>
         {
                        new object[] { CubeFace.Up, new char[3, 3]
                        {
                            { 'W', 'W', 'B' },
                            { 'W', 'W', 'B' },
                            { 'W', 'W', 'B' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'Y', 'Y', 'G' },
                            { 'Y', 'Y', 'G' },
                            { 'Y', 'Y', 'G' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'G', 'G', 'W' },
                            { 'G', 'G', 'W' },
                            { 'G', 'G', 'W' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'Y', 'B', 'B' },
                            { 'Y', 'B', 'B' },
                            { 'Y', 'B', 'B' }
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
        [InlineData(true, "R")]
        [InlineData(false, "R'")]
        public void GetDescription(bool clockwise, string expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new RightCommand((RubiksCube)cube, clockwise);

            string actual = _sut.GetDescription();

            Assert.Equal(expected, actual);
        }
    }
}
