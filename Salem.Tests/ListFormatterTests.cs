using Xunit;
using Pastel;
using System.Drawing;
using System.Collections.Generic;

namespace Salem.Tests
{
    public class ListFormatterTests
    {
        [Fact]
        public void TestFormatterWithoutScope()
        {
            var logger = new Logger();
            var output = new SyntheticOutput();
            var list = new List<string> { "first", "second" };

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            logger.Log("info", list);

            Assert.Equal($"{"[i]".Pastel(Color.Cyan)} { Ansi.Underline("Info").Pastel(Color.Cyan) + "      " } { "first".Pastel(logger.Colors[1]) }", output.Lines[0]);
            Assert.Equal($"             { "  second".Pastel(logger.Colors[1]) }", output.Lines[1]);
        }

        [Fact]
        public void TestFormatterWithScope()
        {
            var logger = new Logger("scope");
            var output = new SyntheticOutput();
            var list = new List<string> { "first", "second" };

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            logger.Log("info", list);

            Assert.Equal($"{ "[scope]".Pastel(logger.Colors[0]) } {"[i]".Pastel(Color.Cyan)} { Ansi.Underline("Info").Pastel(Color.Cyan) + "      " } { "first".Pastel(logger.Colors[1]) }", output.Lines[0]);
            Assert.Equal($"{ "[scope]".Pastel(logger.Colors[0]) }              { "  second".Pastel(logger.Colors[1]) }", output.Lines[1]);
        }
    }
}