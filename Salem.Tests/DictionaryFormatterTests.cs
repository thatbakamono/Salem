using Xunit;
using Pastel;
using System.Drawing;
using System.Collections.Generic;

namespace Salem.Tests
{
    public class DictionaryFormatterTests
    {
        [Fact]
        public void TestFormatterWithoutScope()
        {
            var logger = new Logger();
            var output = new SyntheticOutput();
            var dictionary = new Dictionary<string, string> { { "1", "first" }, { "2", "second" } };

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            logger.Log("info", dictionary);

            Assert.Equal($"{"[i]".Pastel(Color.Cyan)} { Ansi.Underline("Info").Pastel(Color.Cyan) + "      " } { "1 = first".Pastel(logger.Colors[1]) }", output.Lines[0]);
            Assert.Equal($"             { "  2 = second".Pastel(logger.Colors[1]) }", output.Lines[1]);
        }

        [Fact]
        public void TestFormatterWithScope()
        {
            var logger = new Logger("scope");
            var output = new SyntheticOutput();
            var dictionary = new Dictionary<string, string> { { "1", "first" }, { "2", "second" } };

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            logger.Log("info", dictionary);

            Assert.Equal($"{ "[scope]".Pastel(logger.Colors[0]) } {"[i]".Pastel(Color.Cyan)} { Ansi.Underline("Info").Pastel(Color.Cyan) + "      " } { "1 = first".Pastel(logger.Colors[1]) }", output.Lines[0]);
            Assert.Equal($"{ "[scope]".Pastel(logger.Colors[0]) }              { "  2 = second".Pastel(logger.Colors[1]) }", output.Lines[1]);
        }
    }
}