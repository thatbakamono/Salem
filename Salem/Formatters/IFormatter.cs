namespace Salem.Formatters
{
    public interface IFormatter
    {
        void Format(string loglevel, object input);
    }

    public interface IFormatter<T> : IFormatter { }
}