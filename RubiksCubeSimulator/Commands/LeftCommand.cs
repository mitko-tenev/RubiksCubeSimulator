﻿using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public class LeftCommand : MoveCommand
    {
        public LeftCommand(RubiksCube cube, bool clockwise) : base(cube, clockwise) { }

        public override void Execute()
        {
            cube.TurnLeft(clockwise);
        }

        public override void Undo()
        {
            cube.TurnLeft(!clockwise);
        }

        public override string GetDescription()
        {
            return clockwise ? "L" : "L'";
        }
    }

}
