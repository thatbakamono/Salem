using Xunit;
using Pastel;
using System.Drawing;
using System.Collections.Generic;

namespace Salem.Tests
{
    public class IListFormatterTests
    {
        [Fact]
        public void Test1()
        {
            var logger = new Logger("");
            var output = new SyntheticOutput();
            var list = new List<string> { "first", "second" };

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            logger.Log("info", list);

            Assert.Equal($"{"[i]".Pastel(Color.Cyan)} { Ansi.Underline("Info").Pastel(Color.Cyan) + "      " } { "first".Pastel(Color.LightGray) }", output.Lines[0]);
            Assert.Equal($"             { "  second".Pastel(Color.Gray) }", output.Lines[1]);
        }
    }
}