using System;
using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    public class DetectCommand : ExecutableCommand
    { 
        // DETECT will sense whether the well directly below is FULL, EMPTY or ERR (if the robot cannot detect the plate)
        override public void Execute(State state) {

            var x = state.X;
            var y = state.Y;

            if (x == null || y == null) {
                Console.WriteLine("ERR");
                return;
            }

            var wellState = state.GetWell(state.X, state.Y).Full;
            Console.WriteLine(wellState ? "FULL" : "EMPTY");
        }
    }
}