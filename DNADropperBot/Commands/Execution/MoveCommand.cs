using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    public class MoveCommand : ExecutableCommandWithArgument
    { 
        // MOVE will move the toy robot one well in the direction specified by the command.
        public MoveCommand(string argument) : base(argument) { 
        }

        private enum MoveDirection{
            N,
            E,
            S,
            W
        }

        private MoveDirection _moveDirection;

        override public void Execute(State state) {
            // Check if the argument is valid
            // If it's invalid, then do nothing
            if (!ValidateArgument()) return;

            switch (_moveDirection) {
                case MoveDirection.N:
                    // Moving N will increment the X value by 1
                    state.X += 1;
                    break;
                case MoveDirection.E:
                    // Moving E will increment the Y value by 1
                    state.Y += 1;
                    break;
                case MoveDirection.S:
                    // Moving S will decrement the X value by 1
                    state.X -= 1;
                    break;
                case MoveDirection.W:
                    // Moving W will decrement the Y value by 1
                    state.Y -= 1;
                    break;
                default:
                    return;
            }
        }

        override protected bool ValidateArgument() {
            // The argument should be one of the following: N, S, E, W

            if (Argument.Length > 1) return false;
            
            switch(Argument) {
                case "N":
                    _moveDirection = MoveDirection.N;
                    break;
                case "E":
                    _moveDirection = MoveDirection.E;
                    break;
                case "S":
                    _moveDirection = MoveDirection.S;
                    break;
                case "W":
                    _moveDirection = MoveDirection.W;
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}