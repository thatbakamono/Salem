using System;
using Xunit;

namespace Salem.Tests
{
    public class ExceptionFormatterTests
    {
        [Fact]
        public void TestFormatterWithoutScope()
        {
            var logger = new Logger();
            var output = new SyntheticOutput();

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            var myTestArgException = new ArgumentException("Hello World");
            logger.Log("error", myTestArgException);

            Assert.Contains("System.ArgumentException: Hello World", output.Lines[0]);
        }

        [Fact]
        public void TestFormatterWithoutScope_NullRef()
        {
            var logger = new Logger();
            var output = new SyntheticOutput();
            var myTestObj = new MyTestClass();

            try
            {
                logger.Outputs.Clear();
                logger.Outputs.Add(output);
                var result = myTestObj.SubClass.Name; // NullRefEx
            }
            catch(Exception ex)
            {
                logger.Log("warning", ex);
            }

            Assert.Contains("NullReferenceException", output.Lines[0]);
        }

        [Fact]
        public void TestFormatterWithScope()
        {
            var logger = new Logger("scope");
            var output = new SyntheticOutput();
            var ex = new Exception("This is a Test - Fake Exception!");

            logger.Outputs.Clear();
            logger.Outputs.Add(output);

            logger.Log("Error", ex);

            Assert.Contains("This is a Test - Fake Exception!", output.Lines[0]);
        }
    }

    public class MyTestClass
    {
        public MyTestSubClass SubClass { get; set; }
    }

    public class MyTestSubClass
    {
        public string Name { get; set; }
    }
}
