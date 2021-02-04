using System;
using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    public class PlaceCommand : ExecutableCommandWithArgument
    { 
        // PLACE will place the robot above the plate in position X,Y.
        public PlaceCommand(string argument) : base(argument) { 
        }

        private int _placeX;
        private int _placeY;

        override public void Execute(State state) {
            // Check if the argument is valid
            // If it's invalid, then do nothing
            if (!ValidateArgument()) return;

            state.X = _placeX;
            state.Y = _placeY;
        }

        override protected bool ValidateArgument() {
            // The argument should be in the following format: X,Y
            var splitArg = Argument.Split(",");

            if (splitArg.Length != 2) return false;

            // Attempt to parse the passed-in values
            try {
                var parsedX = Int32.Parse(splitArg[0]);
                var parsedY = Int32.Parse(splitArg[1]);

                // If the initial placement coordinates are invalid, don't place it 
                if (parsedX > 5 || parsedX < 0 || parsedY > 5 || parsedY < 0) return false;

                _placeX = parsedX;
                _placeY = parsedY;
            } catch {
                return false;
            }

            return true;
        }
    }
}