using System;

namespace Salem.Outputs
{
    public class ConsoleOutput : IOutput
    {
        private static object lck = new object();

        public void WriteLine(string input)
        {
            lock (lck)
            {
                Console.WriteLine(input);
            }
        }
    }
}