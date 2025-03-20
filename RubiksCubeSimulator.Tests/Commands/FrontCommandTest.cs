using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Tests.Commands
{
    public class FrontCommandTest
    {
        private FrontCommand? _sut;

        [Theory]
        [MemberData(nameof(ClockwiseData))]
        public void Execute_Clockwise(CubeFace face, char[,] expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new FrontCommand((RubiksCube)cube, true);

            this._sut.Execute();

            Assert.Equal(expected, cube.GetFace(face));
        }

        public static IEnumerable<object[]> ClockwiseData =>
        new List<object[]>
        {
                        new object[] { CubeFace.Up, new char[3, 3]
                        {
                            { 'W', 'W', 'W' },
                            { 'W', 'W', 'W' },
                            { 'O', 'O', 'O' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'R', 'R', 'R' },
                            { 'Y', 'Y', 'Y' },
                            { 'Y', 'Y', 'Y' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'G', 'G', 'G' },
                            { 'G', 'G', 'G' },
                            { 'G', 'G', 'G' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'B', 'B', 'B' },
                            { 'B', 'B', 'B' },
                            { 'B', 'B', 'B' }
                        } },
                        new object[] { CubeFace.Left, new char[3, 3]
                        {
                            { 'O', 'O', 'Y' },
                            { 'O', 'O', 'Y' },
                            { 'O', 'O', 'Y' }
                        } }
                        ,
                        new object[] { CubeFace.Right, new char[3, 3]
                        {
                            { 'W', 'R', 'R' },
                            { 'W', 'R', 'R' },
                            { 'W', 'R', 'R' }
                        } }
        };


        [Theory]
        [MemberData(nameof(CounterClockwiseData))]
        public void Execute_CounterClockwise(CubeFace face, char[,] expected)
        {

            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new FrontCommand((RubiksCube)cube, false);

            this._sut.Execute();

            Assert.Equal(expected, cube.GetFace(face));
        }



        public static IEnumerable<object[]> CounterClockwiseData =>
         new List<object[]>
         {
                        new object[] { CubeFace.Up, new char[3, 3]
                        {
                            { 'W', 'W', 'W' },
                            { 'W', 'W', 'W' },
                            { 'R', 'R', 'R' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'O', 'O', 'O' },
                            { 'Y', 'Y', 'Y' },
                            { 'Y', 'Y', 'Y' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'G', 'G', 'G' },
                            { 'G', 'G', 'G' },
                            { 'G', 'G', 'G' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'B', 'B', 'B' },
                            { 'B', 'B', 'B' },
                            { 'B', 'B', 'B' }
                        } },
                        new object[] { CubeFace.Left, new char[3, 3]
                        {
                            { 'O', 'O', 'W' },
                            { 'O', 'O', 'W' },
                            { 'O', 'O', 'W' }
                        } }
                        ,
                        new object[] { CubeFace.Right, new char[3, 3]
                        {
                            { 'Y', 'R', 'R' },
                            { 'Y', 'R', 'R' },
                            { 'Y', 'R', 'R' }
                        } }
         };

        [Theory]
        [InlineData(true, "F")]
        [InlineData(false, "F'")]
        public void GetDescription(bool clockwise, string expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new FrontCommand((RubiksCube)cube, clockwise);

            string actual = _sut.GetDescription();

            Assert.Equal(expected, actual);
        }
    }
}
