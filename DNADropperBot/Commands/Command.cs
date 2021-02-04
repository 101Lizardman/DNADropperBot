using System;

namespace DNADropperBot.Commands
{
    public class Command
    { 

        private CommandEnum _type;
        private string _argument;

        public Command(CommandEnum type) {
            _type = type;
        }

        public Command(CommandEnum type, string argument) {
            _type = type;
            _argument = argument;
        }

        public CommandEnum Type {
            get {
                return _type;
            }
        }

        public string Argument {
            get {
                return _argument;
            }
        }
    }
}