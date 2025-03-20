using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Tests.Commands
{
    public class UpCommandTest
    {
        private UpCommand? _sut;

        [Theory]
        [MemberData(nameof(ClockwiseData))]
        public void Execute_Clockwise(CubeFace face, char[,] expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new UpCommand((RubiksCube)cube, true);

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
                            { 'R', 'R', 'R' },
                            { 'G', 'G', 'G' },
                            { 'G', 'G', 'G' }
                        } },
                        new object[] { CubeFace.Back, new char[3, 3]
                        {
                            { 'O', 'O', 'O' },
                            { 'B', 'B', 'B' },
                            { 'B', 'B', 'B' }
                        } },
                        new object[] { CubeFace.Left, new char[3, 3]
                        {
                            { 'G', 'G', 'G' },
                            { 'O', 'O', 'O' },
                            { 'O', 'O', 'O' }
                        } }
                        ,
                        new object[] { CubeFace.Right, new char[3, 3]
                        {
                            { 'B', 'B', 'B' },
                            { 'R', 'R', 'R' },
                            { 'R', 'R', 'R' }
                        } }
          };

        [Theory]
        [MemberData(nameof(CounterClockwiseData))]
        public void Execute_CounterClockwise(CubeFace face, char[,] expected)
        {

            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new UpCommand((RubiksCube)cube, false);

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
                    { 'O', 'O', 'O' },
                    { 'G', 'G', 'G' },
                    { 'G', 'G', 'G' }
                } },
                new object[] { CubeFace.Back, new char[3, 3]
                {
                    { 'R', 'R', 'R' },
                    { 'B', 'B', 'B' },
                    { 'B', 'B', 'B' }
                } },
                new object[] { CubeFace.Left, new char[3, 3]
                {
                    { 'B', 'B', 'B' },
                    { 'O', 'O', 'O' },
                    { 'O', 'O', 'O' }
                } }
                ,
                new object[] { CubeFace.Right, new char[3, 3]
                {
                    { 'G', 'G', 'G' },
                    { 'R', 'R', 'R' },
                    { 'R', 'R', 'R' }
                } }
          };

        [Theory]
        [InlineData(true, "U")]
        [InlineData(false, "U'")]
        public void GetDescription(bool clockwise, string expected)
        {
            ICube cube = CubeFactory.CreateStandardCube();

            this._sut = new UpCommand((RubiksCube)cube, clockwise);

            string actual = _sut.GetDescription();

            Assert.Equal(expected, actual);
        }
    }
}
