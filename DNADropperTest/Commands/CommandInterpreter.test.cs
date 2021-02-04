using NUnit.Framework;
using System.IO;
using DNADropperBot.Commands;
using DNADropperBot.Utils;
using DNADropperTest.Utils;

namespace DNADropperTest
{
    public class CommandInterpreterTest
    {
        FileReader _fileReader;
        CommandInterpreter _commandInterpreter;
        string sampleFileDir = "../../../SampleFiles/";
        CommandTestUtils _testUtils;

        [SetUp]
        public void Setup()
        {
            _fileReader = new FileReader();
            _commandInterpreter = new CommandInterpreter();
            _testUtils = new CommandTestUtils();
        }


        [Test]
        public void InterpretCorrectCommands()
        {
            var filePath = sampleFileDir + "Instructions/a.txt";
            string[] fileContents = _fileReader.ReadFile(filePath);
            Command[] interpretedCommands = _commandInterpreter.InterpretCommands(fileContents);

            Command[] correctCommands = { 
                new Command(CommandEnum.PLACE, "1,1"),
                new Command(type: CommandEnum.MOVE, "N"),
                new Command(type: CommandEnum.REPORT)
            };

            Assert.IsTrue(_testUtils.CompareCommandArrays(interpretedCommands, correctCommands));
        }

        [Test]
        public void InterpretMalformedCommands()
        {
            var filePath = sampleFileDir + "Instructions/b.txt";
            string[] fileContents = _fileReader.ReadFile(filePath);
            Command[] interpretedCommands = _commandInterpreter.InterpretCommands(fileContents);

            Command[] correctCommands = { };

            Assert.IsTrue(_testUtils.CompareCommandArrays(interpretedCommands, correctCommands));
        }

        [Test]
        public void IgnoreMalformedCommands()
        {
            var filePath = sampleFileDir + "Instructions/c.txt";
            string[] fileContents = _fileReader.ReadFile(filePath);
            Command[] interpretedCommands = _commandInterpreter.InterpretCommands(fileContents);

            Command[] correctCommands = { 
                new Command(CommandEnum.PLACE, "1,2"),
                new Command(type: CommandEnum.MOVE, "E"),
                new Command(type: CommandEnum.REPORT)
            };

            Assert.IsTrue(_testUtils.CompareCommandArrays(interpretedCommands, correctCommands));
        }
        
    }
}