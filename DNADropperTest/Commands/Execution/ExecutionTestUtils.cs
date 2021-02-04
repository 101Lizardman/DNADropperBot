using System;
using DNADropperBot.Commands;
using DNADropperBot.Core;
using DNADropperBot.Commands.Execution;

namespace DNADropperTest.Utils
{
    public class ExecutionTestUtils {

        
        public void ExecuteAllCommands(Command[] commands, State state) {

            CommandExecutor commandExecutor = new CommandExecutor();

            foreach (Command command in commands) {
                commandExecutor.ExecuteCommand(command, state);
            }
        }

        public bool CompareStates(State state1, State state2) {
            return ((state1.X == state2.X) && (state1.Y == state2.Y) && CompareStateWells(state1.Wells, state2.Wells));
        }

        public bool CompareStateWells(Well[,] well1, Well[,] well2) {
            if (well1.GetLength(0) != well2.GetLength(0) || well1.GetLength(1) != well2.GetLength(1)) return false;
            for (int i = 0; i < well1.GetLength(0); i++) {
                for (int j = 0; j < well1.GetLength(1); j++) {
                    if (well1[i,j].Full != well2[i,j].Full) return false;
                }
            }
            return true;
        }

        public State InitializeState(int? x, int? y, bool wellsFull) {
            var newWellArray = new Well[5,5];

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    newWellArray[i,j] = new Well(wellsFull);
                }
            }

            return new State(x, y, newWellArray);
        }

    }
}