using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Tests.Models
{
    public class RubiksCubeTest
    {
        private readonly RubiksCube _sut;

        public RubiksCubeTest()
        {
            _sut = new RubiksCube();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void GetFace(CubeFace face, char[, ] expected)
        {
            var upFace = this._sut.GetFace(face);

            Assert.Equal(expected, upFace);
        }

        [Fact]
        public void GetFace_Throws_For_Unknown_Face()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => this._sut.GetFace((CubeFace)34));

            Assert.Equal("Invalid face", exception.Message);
        }


        public static IEnumerable<object[]> Data =>
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

    }
}
