using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    public class DropCommand : ExecutableCommand
    { 
        // DROP place a drop of liquid into the well directly below the robot
        override public void Execute(State state) {
            state.GetWell(state.X, state.Y).Fill();
        }
    }
}