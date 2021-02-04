using System;
using DNADropperBot.Utils;
using DNADropperBot.Commands;
using DNADropperBot.Commands.Execution;
using DNADropperBot.Core;

namespace DNADropperBot
{
    class Program
    {

        // Shane Vincent
        // https://github.com/101Lizardman
        // vincent.shane101@gmail.com

        // Assumptions / Notes: 
        // - The robot can only ever start within the 5x5 grid
        // - Attempting to move outside of the 5x5 grid will instead just result in no change in position
        // - The robot will never run out of solution to pipette
        // - It was never really specified what the DETECT command really does. I decided that it should print to console.
        // - A well can never "overflow", if it is full and the DROP command is used on it, it just stays full.
        // - I found it a little strange how you declared the North/South direction to be X and the East/West direction to be Y
        // - You specified that the robot "must be prevented from moving beyond the boundaries of the plate" but also declared elsewhere that the robot
        // - The examples of outputs you provided were not inherently true and were missing information

        static void Main(string[] args)
        {
            // Instantiate the State
            State state = new State();

            // Check for input filename as argument
            if (args.Length == 0 || args.Length > 1) {
                PrintError("Incorrect number of arguments. Must have exactly one argument, the path to the input file");
                return;
            }

            var pathToFile = args[0];

            // Read the file
            var fileContents = new FileReader().ReadFile(pathToFile);

            // Interpret any commands
            var commands = new CommandInterpreter().InterpretCommands(fileContents);

            // Confirm validity of commands
            var validCommands = new CommandValidityConfirmer().ValidateCommands(commands);
            if (validCommands == null) return;

            // Execute commands
            var commandExecutor = new CommandExecutor();
            foreach (Command command in validCommands) {
                commandExecutor.ExecuteCommand(command, state);
            }
        }

        private static void PrintError(string message) {
            Console.WriteLine("Error: " + message);
        }
    }
}
