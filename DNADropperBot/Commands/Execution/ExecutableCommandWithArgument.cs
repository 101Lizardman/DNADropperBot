using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    abstract public class ExecutableCommandWithArgument : ExecutableCommand
    { 
        // Parent executable command class that has arguments
        private string _argument;

        public string Argument {
            get {
                return _argument;
            }
        }

        public ExecutableCommandWithArgument(string argument) {
            _argument = argument;
        }

        // Argument commands require a validation check of the argument
        abstract protected bool ValidateArgument();
    }
}