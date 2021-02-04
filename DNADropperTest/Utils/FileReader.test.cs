using NUnit.Framework;
using System.IO;
using DNADropperBot.Utils;

namespace DNADropperTest
{
    public class FileReaderTest
    {
        FileReader _fileReader;
        string sampleFileDir = "../../../SampleFiles/";

        [SetUp]
        public void Setup()
        {
            _fileReader = new FileReader();
        }

        [Test]
        public void TestRead()
        {
            var _filePath = sampleFileDir + "Instructions/a.txt";
            string[] fileRead = _fileReader.ReadFile(_filePath);

            string[] fileContents = { "PLACE 1,1","MOVE N","REPORT" };

            Assert.AreEqual(fileRead, fileContents);
        }
    }
}