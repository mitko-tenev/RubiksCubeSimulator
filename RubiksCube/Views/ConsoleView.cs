using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Views
{
    public class ConsoleView : ICubeView
    {
        public void DisplayCube(ICube cube)
        {
            char[,] up = cube.GetFace(CubeFace.Up);
            char[,] front = cube.GetFace(CubeFace.Front);
            char[,] left = cube.GetFace(CubeFace.Left);
            char[,] right = cube.GetFace(CubeFace.Right);
            char[,] back = cube.GetFace(CubeFace.Back);
            char[,] down = cube.GetFace(CubeFace.Down);

            // Display the cube in unfolded form
            Console.WriteLine("      +-------+");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("      |");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + up[i, j] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+-------+-------+-------+-------+");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + left[i, j] + " ");
                }
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + front[i, j] + " ");
                }
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + right[i, j] + " ");
                }
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + back[i, j] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+-------+-------+-------+-------+");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("      |");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + down[i, j] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("      +-------+");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetUserInput()
        {
            Console.Write("\nEnter command: ");
            return Console.ReadLine().Trim();
        }

        public void DisplayHelp()
        {
            Console.WriteLine("Rubik's Cube Simulator");
            Console.WriteLine("Colors: White (Up), Green (Front), Orange (Left), Red (Right), Blue (Back), Yellow (Down)");
            Console.WriteLine("Commands:");
            Console.WriteLine("  U, D, L, R, F, B (clockwise)");
            Console.WriteLine("  U', D', L', R', F', B' (counterclockwise)");
            Console.WriteLine("  test - test the solution by executing the sequence: F R' U B' L D'");
            Console.WriteLine("  display - Show the cube");
            Console.WriteLine("  reset - Reset the cube to solved state");
            Console.WriteLine("  help - Display this help message");
            Console.WriteLine("  quit - Exit the program");
            Console.WriteLine("  undo - Undo the last move");
        }
    }
}
