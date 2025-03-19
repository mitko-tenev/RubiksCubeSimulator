using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Models;
using RubiksCubeSimulator.Views;

namespace RubiksCubeSimulator.Controllers
{
    public class CubeController
    {
        private readonly ICube cube;
        private readonly ICubeView view;
        private readonly Stack<IMoveCommand> moveHistory;

        public CubeController(ICube cube, ICubeView view)
        {
            this.cube = cube;
            this.view = view;
            this.moveHistory = new Stack<IMoveCommand>();
        }

        public void Run()
        {
            view.DisplayHelp();
            view.DisplayCube(cube);

            bool running = true;
            while (running)
            {
                string input = view.GetUserInput();

                switch (input.ToLower())
                {
                    case "display":
                        view.DisplayCube(cube);
                        break;
                    case "reset":
                        cube.Reset();
                        moveHistory.Clear();
                        view.DisplayMessage("Cube reset to solved state.");
                        break;
                    case "help":
                        view.DisplayHelp();
                        break;
                    case "quit":
                        running = false;
                        break;
                    case "undo":
                        if (moveHistory.Count > 0)
                        {
                            IMoveCommand lastMove = moveHistory.Pop();
                            lastMove.Undo();
                            view.DisplayMessage($"Undid move: {lastMove.GetDescription()}");
                        }
                        else
                        {
                            view.DisplayMessage("No moves to undo.");
                        }
                        break;
                    default:
                        ProcessMoves(input);
                        break;
                }
            }
        }

        private void ProcessMoves(string moves)
        {
            if (string.IsNullOrWhiteSpace(moves))
                return;

            List<IMoveCommand> commands = new List<IMoveCommand>();

            for (int i = 0; i < moves.Length; i++)
            {
                char move = moves[i];
                bool clockwise = true;

                // Check if the next character is ' (counterclockwise)
                if (i + 1 < moves.Length && moves[i + 1] == '\'')
                {
                    clockwise = false;
                    i++; // Skip the ' character
                }

                if (char.IsLetter(move))
                {
                    try
                    {
                        IMoveCommand command = CommandFactory.CreateCommand((RubiksCube)cube, move, clockwise);
                        commands.Add(command);
                    }
                    catch (ArgumentException ex)
                    {
                        view.DisplayMessage(ex.Message);
                    }
                }
            }

            // Execute all valid commands
            foreach (var command in commands)
            {
                cube.ApplyMove(command);
                moveHistory.Push(command);
                view.DisplayMessage($"Applied move: {command.GetDescription()}");
            }
        }
    }
}
