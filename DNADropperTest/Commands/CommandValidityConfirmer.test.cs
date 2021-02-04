using NUnit.Framework;
using System.IO;
using DNADropperBot.Commands;
using DNADropperBot.Utils;
using DNADropperTest.Utils;

namespace DNADropperTest
{
    public class CommandValidityConfirmerTest
    {
        FileReader _fileReader;
        CommandInterpreter _commandInterpreter;
        CommandValidityConfirmer _commandValidityConfirmer;
        string sampleFileDir = "../../../SampleFiles/";
        CommandTestUtils _testUtils;

        [SetUp]
        public void Setup()
        {
            _fileReader = new FileReader();
            _commandInterpreter = new CommandInterpreter();
            _commandValidityConfirmer = new CommandValidityConfirmer();
            _testUtils = new CommandTestUtils();
        }

        [Test]
        public void ValidateCleanCommands()
        {
            var filePath = sampleFileDir + "Instructions/a.txt";
            string[] fileContents = _fileReader.ReadFile(filePath);
            Command[] interpretedCommands = _commandInterpreter.InterpretCommands(fileContents);
            Command[] validatedCommands = _commandValidityConfirmer.ValidateCommands(interpretedCommands);

            Command[] correctCommands = { 
                new Command(CommandEnum.PLACE, "1,1"),
                new Command(type: CommandEnum.MOVE, "N"),
                new Command(type: CommandEnum.REPORT)
            };

            Assert.IsTrue(_testUtils.CompareCommandArrays(validatedCommands, correctCommands));
        }

        [Test]
        public void ParseOutInvalidCommands()
        {
            var filePath = sampleFileDir + "Instructions/d.txt";
            string[] fileContents = _fileReader.ReadFile(filePath);
            Command[] interpretedCommands = _commandInterpreter.InterpretCommands(fileContents);
            Command[] validatedCommands = _commandValidityConfirmer.ValidateCommands(interpretedCommands);

            Command[] correctCommands = { 
                new Command(CommandEnum.PLACE, "1,1"),
                new Command(type: CommandEnum.MOVE, "W"),
                new Command(type: CommandEnum.REPORT)
            };

            Assert.IsTrue(_testUtils.CompareCommandArrays(validatedCommands, correctCommands));
        }
        
    }
}