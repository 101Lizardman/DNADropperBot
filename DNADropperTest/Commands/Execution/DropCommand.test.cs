using NUnit.Framework;
using DNADropperBot.Commands;
using DNADropperBot.Commands.Execution;
using DNADropperBot.Core;
using DNADropperTest.Utils;

namespace DNADropperTest
{
    public class DropCommandTest
    {
        private State _state;
        private State _fullWellState;
        private CommandExecutor _commandExecutor;
        private ExecutionTestUtils _testUtils;

        [SetUp]
        public void Setup()
        {
            _testUtils = new ExecutionTestUtils();
            _commandExecutor = new CommandExecutor();
            _state = _testUtils.InitializeState(1,1,false);
            _fullWellState = _testUtils.InitializeState(1,1,true);
        }


        [Test]
        public void DropInEmptyWell()
        {
            var command = new Command(CommandEnum.PLACE, "3,3");
            _testUtils.ExecuteAllCommands(new Command[] { command }, _state);
            Assert.IsFalse(_state.GetWell(3,3).Full);

            command = new Command(CommandEnum.DROP);
            _testUtils.ExecuteAllCommands(new Command[] { command }, _state);
            Assert.IsTrue(_state.GetWell(3,3).Full);
        }

        [Test]
        public void DropInFullWellDoesNothing()
        {
            var command = new Command(CommandEnum.PLACE, "3,3");
            _testUtils.ExecuteAllCommands(new Command[] { command }, _fullWellState);
            Assert.IsTrue(_fullWellState.GetWell(3,3).Full);

            command = new Command(CommandEnum.DROP);
            _testUtils.ExecuteAllCommands(new Command[] { command }, _fullWellState);
            Assert.IsTrue(_fullWellState.GetWell(3,3).Full);

        }
        
    }
}