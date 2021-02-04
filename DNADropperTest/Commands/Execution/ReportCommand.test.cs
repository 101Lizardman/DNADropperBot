using NUnit.Framework;
using System;
using System.IO;
using DNADropperBot.Commands;
using DNADropperBot.Commands.Execution;
using DNADropperBot.Core;
using DNADropperTest.Utils;

namespace DNADropperTest
{
    public class ReportCommandTest
    {
        private State _state;
        private State _fullWellState;
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
            _stringWriter = new StringWriter();

            // For this test we will have to pipe the output from Console.WriteLine to local
            // Console.WriteLine will add newline characters afterwards
            _newLineCharacters = "\r\n";
        }

        [Test]
        public void ReportEmptyWellAtThreeThree()
        {
            using (_stringWriter) {
                Console.SetOut(_stringWriter);

                var commands = new Command[] {
                    new Command(CommandEnum.PLACE, "3,3"),
                    new Command(CommandEnum.REPORT),
                };
                _testUtils.ExecuteAllCommands(commands, _state);

                Assert.AreEqual("3,3,EMPTY" + _newLineCharacters, _stringWriter.ToString());
            }
        }

        [Test]
        public void ReportFullWellAtOneFive()
        {
            using (_stringWriter) {
                Console.SetOut(_stringWriter);

                var commands = new Command[] {
                    new Command(CommandEnum.PLACE, "1,5"),
                    new Command(CommandEnum.REPORT),
                };
                _testUtils.ExecuteAllCommands(commands, _fullWellState);

                Assert.AreEqual("1,5,FULL" + _newLineCharacters, _stringWriter.ToString());
            }
        }

        [Test]
        public void DropInWellsAndReport()
        {
            using (_stringWriter) {
                Console.SetOut(_stringWriter);

                var commands = new Command[] {
                    new Command(CommandEnum.PLACE, "1,1"),
                    new Command(CommandEnum.DROP),
                    new Command(CommandEnum.REPORT)
                };
                _testUtils.ExecuteAllCommands(commands, _state);
                var consoleOutput = "1,1,FULL" + _newLineCharacters;

                commands = new Command[] {
                    new Command(CommandEnum.MOVE, "E"),
                    new Command(CommandEnum.REPORT)
                };
                _testUtils.ExecuteAllCommands(commands, _state);
                consoleOutput += "1,2,EMPTY" + _newLineCharacters;

                commands = new Command[] {
                    new Command(CommandEnum.DROP),
                    new Command(CommandEnum.REPORT)
                };
                _testUtils.ExecuteAllCommands(commands, _state);
                consoleOutput += "1,2,FULL" + _newLineCharacters;

                Assert.AreEqual(consoleOutput, _stringWriter.ToString());
            }
        }
    }
}