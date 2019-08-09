using Salem.Outputs;
using System.Collections.Generic;

namespace Salem.Tests
{
    public class SyntheticOutput : IOutput
    {
        public IReadOnlyList<string> Lines => lines;

        private List<string> lines = new List<string>();

        public void WriteLine(string input) => 
            lines.Add(input);

        public void Clear() => 
            lines.Clear();
    }
}