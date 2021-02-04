using System.Linq;
using System.Collections.Generic;

namespace DNADropperBot.Commands
{
    public class CommandValidityConfirmer
    { 
        public CommandValidityConfirmer() {

        }

        // The first valid command must be a PLACE command
        // Any commands prior to the first PLACE command are ignored
        public Command[] ValidateCommands(Command[] commands) {
            for (int i = 0; i < commands.Length; i++) {
                if (commands[i].Type == CommandEnum.PLACE) return commands.Skip(i).Take(commands.Length - i).ToArray();
            }
            return null;
        }
    }
}