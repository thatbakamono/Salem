using System;

namespace Salem.Formatters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Formatter : Attribute
    {
        public Type Type { get; }
    
        public Formatter(Type type)
        {
            Type = type;
        }
    }
}