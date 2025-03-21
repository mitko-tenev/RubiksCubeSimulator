# Rubiks Cube Simulator

This repository contains a CLI program that simulates a rubiks cube. It is written in .NET and C#.
Website where the cube can be visualized: [https://rubiks-cube-solver.com/](https://rubiks-cube-solver.com/).

## How to run the project:
**Before running this project make sure to:**
- download and install .NET 8 SDK (it can be downloaded from here for your OS: https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- make sure `dotnet` is available in the PATH varible (check by running `dotnet` in a command prompt and verify you see the helper text):
  
 ![image](https://github.com/user-attachments/assets/bac75ff9-da8d-4411-9d3c-b5ebf0ee35f4)

## To run the project
1. Clone this repo: `git clone https://github.com/mitko-tenev/RubiksCubeSimulator.git`
2. Go into the `RubiksCubeSimulator` directory after cloning with `cd RubiksCubeSimulator` command
3. Run `dotnet restore` and `dotnet build` to build the project and restore dependencies
4. Run `dotnet run --project RubiksCubeSimulator\RubiksCubeSimulator.csproj`
5. You should see this interface:
![image](https://github.com/user-attachments/assets/0b800ee4-73bb-4481-a484-a37b1692848b)

The sides of the cube are represented with the same colors as in the rubiks-cube-solver website.

The initial state of the cube is "solved".

To quickly test the solution to the following sequence: `F R' U B' L D'`, run the `test` command in the app CLI. The result should be the following:

![image](https://github.com/user-attachments/assets/284c203f-cde1-4a84-b0e9-cf94f61719e5)

## Project structure
The project follows the MVC architecture and uses the Commands design patterns to issue commands to the cube. The project is split into the following parts:
 - Commands - contains the commands to be sent to the cube (such as UpCommand to turn the UP Side of the cube clockwise or counterclockwise)
 - Controllers - contains the controller that accepts user commands from the CLI and orchestrates the execution of commands, also contains "undo" logic to undo executed commands
 - Factories - contains factories that create Command and Cube objects
 - Models - contains the model and logic of the cube
 - Views - contains the view that writes to the console
 - Program.cs - this is the file that contains the main logic of the app when it is executed
   
The project also contains another assembly with unit tests.

## How to run the tests:
This project also includes tests, to run them execute the following commands from the root of the project:
1. `dotnet restore` and `dotnet build` to build the project and restore dependencies
2. `dotnet test RubiksCubeSimulator.Tests\RubiksCubeSimulator.Tests.csproj`
![image](https://github.com/user-attachments/assets/7253e5c2-184e-4351-86e0-18b5bbeb6cc2)
