using DNADropperBot.Core;

namespace DNADropperBot.Commands.Execution
{
    public class CommandExecutor
    { 
        public CommandExecutor() { }

        public void ExecuteCommand(Command command, State state) {
            switch (command.Type) {
                case (CommandEnum.PLACE):
                    new PlaceCommand(command.Argument).Execute(state);
                    break;
                case (CommandEnum.MOVE):
                    new MoveCommand(command.Argument).Execute(state);
                    break;
                case (CommandEnum.DROP):
                    new DropCommand().Execute(state);
                    break;
                case (CommandEnum.DETECT):
                    new DetectCommand().Execute(state);
                    break;
                case (CommandEnum.REPORT):
                    new ReportCommand().Execute(state);
                    break;
                default:
                    break;
            }
        }
    }
}