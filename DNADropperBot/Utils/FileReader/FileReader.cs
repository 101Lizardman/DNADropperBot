namespace DNADropperBot.Utils
{
    public class FileReader
    { 
        public string[] ReadFile(string pathToFile) {
            return System.IO.File.ReadAllLines(pathToFile);
        }
    }
}