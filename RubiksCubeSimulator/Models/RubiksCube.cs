using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Commands;

namespace RubiksCubeSimulator.Models
{
    public class RubiksCube : ICube
    {
        private char[,] up;    // White
        private char[,] front; // Green
        private char[,] left;  // Orange
        private char[,] right; // Red
        private char[,] back;  // Blue
        private char[,] down;  // Yellow

        public RubiksCube()
        {
            // make sure arrays are always initialized
            up = new char[3, 3];
            front = new char[3, 3];
            left = new char[3, 3];
            right = new char[3, 3];
            back = new char[3, 3];
            down = new char[3, 3];

            Reset();
        }

        /**
         * Rotates the cube to the default (solved) state
         */
        public void Reset()
        {
            // Initialize cube with solved state
            up = new char[3, 3];
            front = new char[3, 3];
            left = new char[3, 3];
            right = new char[3, 3];
            back = new char[3, 3];
            down = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    up[i, j] = 'W';    // White
                    front[i, j] = 'G'; // Green
                    left[i, j] = 'O';  // Orange
                    right[i, j] = 'R'; // Red
                    back[i, j] = 'B';  // Blue
                    down[i, j] = 'Y';  // Yellow
                }
            }
        }

        /*
         * Getter method - used to get the values of a particular cube face
         */
        public char[,] GetFace(CubeFace face)
        {
            switch (face)
            {
                case CubeFace.Up:
                    return up;
                case CubeFace.Front:
                    return front;
                case CubeFace.Left:
                    return left;
                case CubeFace.Right:
                    return right;
                case CubeFace.Back:
                    return back;
                case CubeFace.Down:
                    return down;
                default:
                    throw new ArgumentException("Invalid face");
            }
        }

        public void ApplyMove(IMoveCommand command)
        {
            command.Execute();
        }

        /**
         * Rotates a provided face of the cube, either clockwise or counterclockwise
         */
        internal void RotateFace(char[,] face, bool clockwise = true)
        {
            char[,] temp = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp[i, j] = face[i, j];
                }
            }

            if (clockwise)
            {
                // Rotate 90 degrees clockwise
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        face[j, 2 - i] = temp[i, j];
                    }
                }
            }
            else
            {
                // Rotate 90 degrees counterclockwise
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        face[2 - j, i] = temp[i, j];
                    }
                }
            }
        }

        internal void TurnUp(bool clockwise)
        {
            RotateFace(up, clockwise);

            char[] temp = new char[3];

            // Save front's top row
            for (int i = 0; i < 3; i++)
            {
                temp[i] = front[0, i];
            }

            if (clockwise)
            {
                // Move right's top row to front's top row
                for (int i = 0; i < 3; i++)
                {
                    front[0, i] = right[0, i];
                }

                // Move back's top row to right's top row
                for (int i = 0; i < 3; i++)
                {
                    right[0, i] = back[0, i];
                }

                // Move left's top row to back's top row
                for (int i = 0; i < 3; i++)
                {
                    back[0, i] = left[0, i];
                }

                // Move saved front's top row to left's top row
                for (int i = 0; i < 3; i++)
                {
                    left[0, i] = temp[i];
                }
            }
            else
            {
                // Move left's top row to front's top row
                for (int i = 0; i < 3; i++)
                {
                    front[0, i] = left[0, i];
                }

                // Move back's top row to left's top row
                for (int i = 0; i < 3; i++)
                {
                    left[0, i] = back[0, i];
                }

                // Move right's top row to back's top row
                for (int i = 0; i < 3; i++)
                {
                    back[0, i] = right[0, i];
                }

                // Move saved front's top row to right's top row
                for (int i = 0; i < 3; i++)
                {
                    right[0, i] = temp[i];
                }
            }
        }

        internal void TurnDown(bool clockwise)
        {
            RotateFace(down, clockwise);

            char[] temp = new char[3];

            // Save front's bottom row
            for (int i = 0; i < 3; i++)
            {
                temp[i] = front[2, i];
            }

            if (clockwise)
            {
                // Move left's bottom row to front's bottom row
                for (int i = 0; i < 3; i++)
                {
                    front[2, i] = left[2, i];
                }

                // Move back's bottom row to left's bottom row
                for (int i = 0; i < 3; i++)
                {
                    left[2, i] = back[2, i];
                }

                // Move right's bottom row to back's bottom row
                for (int i = 0; i < 3; i++)
                {
                    back[2, i] = right[2, i];
                }

                // Move saved front's bottom row to right's bottom row
                for (int i = 0; i < 3; i++)
                {
                    right[2, i] = temp[i];
                }
            }
            else
            {
                // Move right's bottom row to front's bottom row
                for (int i = 0; i < 3; i++)
                {
                    front[2, i] = right[2, i];
                }

                // Move back's bottom row to right's bottom row
                for (int i = 0; i < 3; i++)
                {
                    right[2, i] = back[2, i];
                }

                // Move left's bottom row to back's bottom row
                for (int i = 0; i < 3; i++)
                {
                    back[2, i] = left[2, i];
                }

                // Move saved front's bottom row to left's bottom row
                for (int i = 0; i < 3; i++)
                {
                    left[2, i] = temp[i];
                }
            }
        }

        internal void TurnLeft(bool clockwise)
        {
            RotateFace(left, clockwise);

            char[] temp = new char[3];

            // Save up's left column
            for (int i = 0; i < 3; i++)
            {
                temp[i] = up[i, 0];
            }

            if (clockwise)
            {
                // Move back's right column to up's left column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    up[i, 0] = back[2 - i, 2];
                }

                // Move down's left column to back's right column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    back[i, 2] = down[2 - i, 0];
                }

                // Move front's left column to down's left column
                for (int i = 0; i < 3; i++)
                {
                    down[i, 0] = front[i, 0];
                }

                // Move saved up's left column to front's left column
                for (int i = 0; i < 3; i++)
                {
                    front[i, 0] = temp[i];
                }
            }
            else
            {
                // Move front's left column to up's left column
                for (int i = 0; i < 3; i++)
                {
                    up[i, 0] = front[i, 0];
                }

                // Move down's left column to front's left column
                for (int i = 0; i < 3; i++)
                {
                    front[i, 0] = down[i, 0];
                }

                // Move back's right column to down's left column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    down[i, 0] = back[2 - i, 2];
                }

                // Move saved up's left column to back's right column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    back[2 - i, 2] = temp[i];
                }
            }
        }

        internal void TurnRight(bool clockwise)
        {
            RotateFace(right, clockwise);

            char[] temp = new char[3];

            // Save up's right column
            for (int i = 0; i < 3; i++)
            {
                temp[i] = up[i, 2];
            }

            if (clockwise)
            {
                // Move front's right column to up's right column
                for (int i = 0; i < 3; i++)
                {
                    up[i, 2] = front[i, 2];
                }

                // Move down's right column to front's right column
                for (int i = 0; i < 3; i++)
                {
                    front[i, 2] = down[i, 2];
                }

                // Move back's left column to down's right column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    down[i, 2] = back[2 - i, 0];
                }

                // Move saved up's right column to back's left column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    back[2 - i, 0] = temp[i];
                }
            }
            else
            {
                // Move back's left column to up's right column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    up[i, 2] = back[2 - i, 0];
                }

                // Move down's right column to back's left column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    back[2 - i, 0] = down[i, 2];
                }

                // Move front's right column to down's right column
                for (int i = 0; i < 3; i++)
                {
                    down[i, 2] = front[i, 2];
                }

                // Move saved up's right column to front's right column
                for (int i = 0; i < 3; i++)
                {
                    front[i, 2] = temp[i];
                }
            }
        }

        internal void TurnFront(bool clockwise)
        {
            RotateFace(front, clockwise);

            char[] temp = new char[3];

            // Save up's bottom row
            for (int i = 0; i < 3; i++)
            {
                temp[i] = up[2, i];
            }

            if (clockwise)
            {
                // Move left's right column to up's bottom row (reversed)
                for (int i = 0; i < 3; i++)
                {
                    up[2, i] = left[2 - i, 2];
                }

                // Move down's top row to left's right column
                for (int i = 0; i < 3; i++)
                {
                    left[i, 2] = down[0, i];
                }

                // Move right's left column to down's top row (reversed)
                for (int i = 0; i < 3; i++)
                {
                    down[0, i] = right[2 - i, 0];
                }

                // Move saved up's bottom row to right's left column
                for (int i = 0; i < 3; i++)
                {
                    right[i, 0] = temp[i];
                }
            }
            else
            {
                // Move right's left column to up's bottom row
                for (int i = 0; i < 3; i++)
                {
                    up[2, i] = right[i, 0];
                }

                // Move down's top row to right's left column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    right[i, 0] = down[0, 2 - i];
                }

                // Move left's right column to down's top row (reversed)
                for (int i = 0; i < 3; i++)
                {
                    down[0, i] = left[i, 2];
                }

                // Move saved up's bottom row to left's right column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    left[i, 2] = temp[2 - i];
                }
            }
        }

        internal void TurnBack(bool clockwise)
        {
            RotateFace(back, clockwise);

            char[] temp = new char[3];

            // Save up's top row
            for (int i = 0; i < 3; i++)
            {
                temp[i] = up[0, i];
            }

            if (clockwise)
            {
                // Move right's right column to up's top row
                for (int i = 0; i < 3; i++)
                {
                    up[0, i] = right[i, 2];
                }

                // Move down's bottom row to right's right column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    right[i, 2] = down[2, 2 - i];
                }

                // Move left's left column to down's bottom row
                for (int i = 0; i < 3; i++)
                {
                    down[2, i] = left[i, 0];
                }

                // Move saved up's top row to left's left column (reversed)
                for (int i = 0; i < 3; i++)
                {
                    left[i, 0] = temp[2 - i];
                }
            }
            else
            {
                // Move left's left column to up's top row (reversed)
                for (int i = 0; i < 3; i++)
                {
                    up[0, i] = left[2 - i, 0];
                }

                // Move down's bottom row to left's left column
                for (int i = 0; i < 3; i++)
                {
                    left[i, 0] = down[2, i];
                }

                // Move right's right column to down's bottom row (reversed)
                for (int i = 0; i < 3; i++)
                {
                    down[2, i] = right[2 - i, 2];
                }

                // Move saved up's top row to right's right column
                for (int i = 0; i < 3; i++)
                {
                    right[i, 2] = temp[i];
                }
            }
        }

    }
}
