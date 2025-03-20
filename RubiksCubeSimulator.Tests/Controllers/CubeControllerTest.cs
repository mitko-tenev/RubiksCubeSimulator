using NSubstitute;
using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Controllers;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;
using RubiksCubeSimulator.Views;

namespace RubiksCubeSimulator.Tests.Controllers
{
    public class CubeControllerTest
    {
        private readonly ICube cubeMock;
        private readonly ICubeView cubeViewMock;
        private readonly ICommandFactory commandFactoryMock;
        private readonly CubeController _sut;

        private readonly IMoveCommand mockCommand;

        public CubeControllerTest()
        {
            cubeMock = Substitute.For<ICube>();
            cubeViewMock = Substitute.For<ICubeView>();
            commandFactoryMock = Substitute.For<ICommandFactory>();
            _sut = new(cubeMock, cubeViewMock, commandFactoryMock);

            mockCommand = Substitute.For<IMoveCommand>();
        }

        [Fact]
        public void Run()
        {
            cubeViewMock.GetUserInput().Returns("quit");

            this._sut.Run();

            cubeViewMock.Received().DisplayHelp();
            cubeViewMock.Received().DisplayCube(cubeMock);
        }

        [Fact]
        public void Run_Throws_For_Null_Input()
        {
            const string expectedMessage = "Value cannot be null. (Parameter 'Invalid input')";
            string? nullInput = null;
            cubeViewMock.GetUserInput().Returns(nullInput);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => this._sut.Run());
            Assert.Equal(expectedMessage, exception.Message);
            cubeViewMock.Received().DisplayHelp();
            cubeViewMock.Received().DisplayCube(cubeMock);
        }


        [Fact]
        public void Run_Display_Command()
        {
            cubeViewMock.GetUserInput().Returns("display", "quit");

            this._sut.Run();

            cubeViewMock.Received().DisplayHelp();
            cubeViewMock.Received().DisplayCube(cubeMock);
        }

        [Fact]
        public void Run_Reset_Command()
        {
            const string expectedDisplayMessage = "Cube reset to solved state.";
            cubeViewMock.GetUserInput().Returns("reset", "quit");

            this._sut.Run();

            cubeViewMock.Received().DisplayHelp();
            cubeViewMock.Received().DisplayCube(cubeMock);
            cubeMock.Received().Reset();
            cubeViewMock.Received().DisplayMessage(expectedDisplayMessage);
        }

        [Fact]
        public void Run_Specific_Command()
        {
            cubeViewMock.GetUserInput().Returns("F", "quit");

            mockCommand.GetDescription().Returns("F");

            commandFactoryMock.CreateCommand(cubeMock, 'F', true).Returns(mockCommand);

            this._sut.Run();

            cubeViewMock.Received().DisplayMessage("Applied move: F");
        }

        [Fact]
        public void Run_Undo_Command()
        {
            cubeViewMock.GetUserInput().Returns("F", "undo", "quit");

            mockCommand.GetDescription().Returns("F");

            commandFactoryMock.CreateCommand(cubeMock, 'F', true).Returns(mockCommand);

            this._sut.Run();

            cubeViewMock.Received().DisplayMessage("Applied move: F");
            cubeViewMock.Received().DisplayMessage("Undid move: F");
        }
    }
}
