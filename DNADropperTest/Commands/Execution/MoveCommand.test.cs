using NUnit.Framework;
using DNADropperBot.Commands;
using DNADropperBot.Commands.Execution;
using DNADropperBot.Core;
using DNADropperTest.Utils;

namespace DNADropperTest
{
    public class MoveCommandTest
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
        public void MoveOneN()
        {
            var command = new Command(CommandEnum.MOVE, "N");
            _testUtils.ExecuteAllCommands(new Command[] { command }, _state);
            _comparrisonState.X += 1;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveFourN()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);
            _comparrisonState.X = 5;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveSixNButStoppingAtEdge()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);
            _comparrisonState.X = 5;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveOneE()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "E"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);
            _comparrisonState.Y += 1;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveFourE()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);
            _comparrisonState.Y = 5;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveSixEButStoppingAtEdge()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);
            _comparrisonState.Y = 5;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveFourEFourN()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "E"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
                new Command(CommandEnum.MOVE, "N"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);
            _comparrisonState.Y = 5;
            _comparrisonState.X = 5;

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveTenWButShouldntMoveAtAll()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
                new Command(CommandEnum.MOVE, "W"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void MoveTenSButShouldntMoveAtAll()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
                new Command(CommandEnum.MOVE, "S"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        [Test]
        public void NotMovingIfInvalidArgumentPassedIn()
        {
            var commands = new Command[] {
                new Command(CommandEnum.MOVE, "@"),
            };

            _testUtils.ExecuteAllCommands(commands, _state);

            Assert.IsTrue(_testUtils.CompareStates(_state, _comparrisonState));
        }

        
    }
}