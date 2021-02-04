using NUnit.Framework;
using System;
using System.IO;
using DNADropperBot.Commands;
using DNADropperBot.Commands.Execution;
using DNADropperBot.Core;
using DNADropperTest.Utils;

namespace DNADropperTest
{
    public class DetectCommandTest
    {
        private State _state;
        private State _fullWellState;
        private State _nullXYState;
        private CommandExecutor _commandExecutor;
        private ExecutionTestUtils _testUtils;
        private StringWriter _stringWriter;
        private string _newLineCharacters;

        [SetUp]
        public void Setup()
        {
            _testUtils = new ExecutionTestUtils();
            _commandExecutor = new CommandExecutor();
            _state = _testUtils.InitializeState(1,1,false);
            _fullWellState = _testUtils.InitializeState(1,1,true);
            _nullXYState = _testUtils.InitializeState(null,null,false);
            _stringWriter = new StringWriter();

            // For this test we will have to pipe the output from Console.WriteLine to local
            // Console.WriteLine will add newline characters afterwards
            _newLineCharacters = "\r\n";
        }

        [Test]
        public void DetectEmptyWell()
        {
            using (_stringWriter) {
                Console.SetOut(_stringWriter);

                var command = new Command(CommandEnum.DETECT);
                _testUtils.ExecuteAllCommands(new Command[] { command }, _state);

                Assert.AreEqual("EMPTY" + _newLineCharacters, _stringWriter.ToString());
            }
        }

        [Test]
        public void DetectFullWell()
        {
            using (_stringWriter) {
                Console.SetOut(_stringWriter);

                var command = new Command(CommandEnum.DETECT);
                _testUtils.ExecuteAllCommands(new Command[] { command }, _fullWellState);

                Assert.AreEqual("FULL" + _newLineCharacters, _stringWriter.ToString());
            }
        }

        [Test]
        public void ErrorInDetectionWhenXYAreNull()
        {
            using (_stringWriter) {
                Console.SetOut(_stringWriter);

                var command = new Command(CommandEnum.DETECT);
                _testUtils.ExecuteAllCommands(new Command[] { command }, _nullXYState);

                Assert.AreEqual("ERR" + _newLineCharacters, _stringWriter.ToString());
            }
        }
    }
}