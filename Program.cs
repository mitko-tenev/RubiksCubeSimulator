﻿using RubiksCubeSimulator.Controllers;
using RubiksCubeSimulator.Factories;
using RubiksCubeSimulator.Models;
using RubiksCubeSimulator.Views;

namespace RubiksCubeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the model through the factory
            ICube cube = CubeFactory.CreateStandardCube();

            // Create the view
            ICubeView view = new ConsoleView();

            // Create the controller
            CubeController controller = new CubeController(cube, view);

            // Start the application
            controller.Run();
        }
    }
}