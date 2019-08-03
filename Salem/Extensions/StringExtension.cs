namespace Salem.Extensions
{
    internal static class StringExtension
    {
        public static string Expand(this string input, int length)
        {
            int inputLength = Ansi.Strip(input).Length;

            while (inputLength < length)
            {
                input += ' ';
                inputLength++;
            }

            return input;
        }
    }
}