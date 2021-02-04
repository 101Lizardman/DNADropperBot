using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    abstract public class ExecutableCommand
    { 
        // Parent class that all executable commands extend from
        abstract public void Execute(State state);
    }
}