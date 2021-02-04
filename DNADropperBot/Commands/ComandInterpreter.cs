using System.Collections.Generic;

namespace DNADropperBot.Commands
{
    public class CommandInterpreter
    { 
        public CommandInterpreter() {

        }

        // Accepts an array of strings and returns Command objects
        // Will only return an object from a valid string, will ignore malformed strings
        public Command[] InterpretCommands(string[] commands) {
            var parsedCommands = new List<Command>();
            
            foreach (string command in commands) {
                var splitCommand = command.Split(' ');

                switch (splitCommand[0]) {
                    case "PLACE":
                        if (splitCommand.Length <= 1) continue;
                        parsedCommands.Add(new Command(CommandEnum.PLACE, splitCommand[1]));
                        break;
                    case "MOVE":
                        if (splitCommand.Length <= 1) continue;
                        parsedCommands.Add(new Command(CommandEnum.MOVE, splitCommand[1]));
                        break;
                    case "DETECT":
                        parsedCommands.Add(new Command(CommandEnum.DETECT));
                        break;
                    case "DROP":
                        parsedCommands.Add(new Command(CommandEnum.DROP));
                        break;
                    case "REPORT":
                        parsedCommands.Add(new Command(CommandEnum.REPORT));
                        break;
                    default:
                        continue;
                }
            }

            return parsedCommands.ToArray();
        }
    }
}