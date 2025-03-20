using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Tests.Commands
{
    public class DownCommandTest
    {
        private DownCommand? _sut;

        [Theory]
        [MemberData(nameof(ClockwiseData))]
        public void Execute_Clockwise(CubeFace face, char[,] expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new DownCommand((RubiksCube)cube, true);

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
                            { 'W', 'W', 'W' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'Y', 'Y', 'Y' },
                            { 'Y', 'Y', 'Y' },
                            { 'Y', 'Y', 'Y' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'G', 'G', 'G' },
                            { 'G', 'G', 'G' },
                            { 'O', 'O', 'O' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'B', 'B', 'B' },
                            { 'B', 'B', 'B' },
                            { 'R', 'R', 'R' }
                        } },
                        new object[] { CubeFace.Left, new char[3, 3]
                        {
                            { 'O', 'O', 'O' },
                            { 'O', 'O', 'O' },
                            { 'B', 'B', 'B' }
                        } }
                        ,
                        new object[] { CubeFace.Right, new char[3, 3]
                        {
                            { 'R', 'R', 'R' },
                            { 'R', 'R', 'R' },
                            { 'G', 'G', 'G' }
                        } }
        };


        [Theory]
        [MemberData(nameof(CounterClockwiseData))]
        public void Execute_CounterClockwise(CubeFace face, char[,] expected)
        {

            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new DownCommand((RubiksCube)cube, false);

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
                            { 'W', 'W', 'W' }
                        } },
                        new object[] { CubeFace.Down, new char[3, 3]
                        {
                            { 'Y', 'Y', 'Y' },
                            { 'Y', 'Y', 'Y' },
                            { 'Y', 'Y', 'Y' }
                        } },
                        new object[] { CubeFace.Front, new char[3, 3]
                        {
                            { 'G', 'G', 'G' },
                            { 'G', 'G', 'G' },
                            { 'R', 'R', 'R' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'B', 'B', 'B' },
                            { 'B', 'B', 'B' },
                            { 'O', 'O', 'O' }
                        } },
                        new object[] { CubeFace.Left, new char[3, 3]
                        {
                            { 'O', 'O', 'O' },
                            { 'O', 'O', 'O' },
                            { 'G', 'G', 'G' }
                        } }
                        ,
                        new object[] { CubeFace.Right, new char[3, 3]
                        {
                            { 'R', 'R', 'R' },
                            { 'R', 'R', 'R' },
                            { 'B', 'B', 'B' }
                        } }
         };


        [Theory]
        [InlineData(true, "D")]
        [InlineData(false, "D'")]
        public void GetDescription(bool clockwise, string expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new DownCommand((RubiksCube)cube, clockwise);

            string actual = _sut.GetDescription();

            Assert.Equal(expected, actual);
        }
    }
}
