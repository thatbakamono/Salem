using System.IO;

namespace Salem.Outputs
{
    public class FileOutput : IOutput
    {
        private static object lck = new object();
        private StreamWriter streamWriter;

        public FileOutput(string file)
        {
            if (File.Exists(file))
            {
                streamWriter = new StreamWriter(file);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void WriteLine(string input)
        {
            lock (lck)
            {
                streamWriter.WriteLine(input);
            }
        }
    }
}