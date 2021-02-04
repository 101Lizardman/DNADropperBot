using NUnit.Framework;
using DNADropperBot.Commands;
using DNADropperBot.Commands.Execution;
using DNADropperBot.Core;
using DNADropperTest.Utils;

namespace DNADropperTest
{
    public class PlaceCommandTest
    {
        private State _state;
        private State _comparrisonState;
        private CommandExecutor _commandExecutor;
        private ExecutionTestUtils _testUtils;

        [SetUp]
        public void Setup()
        {
            _testUtils = new ExecutionTestUtils();
            _commandExecutor = new CommandExecutor();
            _state = _testUtils.InitializeState(1,1,false);
            _comparrisonState = _testUtils.InitializeState(1,1,false);
        }


        [Test]
        public void PlaceAtThreeThree()
        {
            var command = new Command(CommandEnum.PLACE, "3,3");
            _testUtils.ExecuteAllCommands(new Command[] { command }, _state);
            _comparrisonState.X = 3;
            _comparrisonState.Y = 3;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void PlaceAtFiveFive()
        {
            var command = new Command(CommandEnum.PLACE, "5,5");
            _testUtils.ExecuteAllCommands(new Command[] { command }, _state);
            _comparrisonState.X = 5;
            _comparrisonState.Y = 5;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void InvalidPlaceCommandDoesntDoAnything()
        {
            var commands = new Command[] {
                new Command(CommandEnum.PLACE, "2,2"),
                new Command(CommandEnum.PLACE, "INVALID,COMMAND"),
            };
            
            _testUtils.ExecuteAllCommands(commands, _state);
            _comparrisonState.X = 2;
            _comparrisonState.Y = 2;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        
    }
}