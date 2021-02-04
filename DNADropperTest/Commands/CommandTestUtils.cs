using DNADropperBot.Commands;

namespace DNADropperTest.Utils
{
    public class CommandTestUtils {

        public bool CompareCommands(Command comm1, Command comm2) {
            return comm1.Type == comm2.Type && comm1.Argument == comm2.Argument;
        }

        public bool CompareCommandArrays(Command[] commArr1, Command[] commArr2) {
            if (commArr1.Length != commArr2.Length) return false;
            for (int i = 0; i < commArr1.Length; i++) {
                if(!CompareCommands(commArr1[i], commArr2[i])) return false;
            }
            return true;
        }
    }
}