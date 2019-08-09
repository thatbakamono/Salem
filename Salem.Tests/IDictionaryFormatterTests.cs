using Xunit;
using Pastel;
using System.Drawing;
using System.Collections.Generic;

namespace Salem.Tests
{
    public class IDictionaryFormatterTests
    {
        [Fact]
        public void Test1()
        {
            var logger = new Logger("");
            var output = new SyntheticOutput();
            var dictionary = new Dictionary<string, string> { { "1", "first" }, { "2", "second" } };

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            logger.Log("info", dictionary);

            Assert.Equal($"{"[i]".Pastel(Color.Cyan)} { Ansi.Underline("Info").Pastel(Color.Cyan) + "      " } { "1 = first".Pastel(Color.LightGray) }", output.Lines[0]);
            Assert.Equal($"             { "  2 = second".Pastel(Color.Gray) }", output.Lines[1]);
        }
    }
}