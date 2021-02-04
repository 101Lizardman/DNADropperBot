using System;
using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    public class ReportCommand : ExecutableCommand
    { 
        // REPORT will announce the X,Y,FULL/EMPTY (the status of the detection of the well below) of the robot arm.
        override public void Execute(State state) {

            var x = state.X;
            var y = state.Y;

            var wellStatus = state.GetWell(x,y).Full ? "FULL" : "EMPTY";
            Console.WriteLine($"{x},{y},{wellStatus}");
        }
    }
}