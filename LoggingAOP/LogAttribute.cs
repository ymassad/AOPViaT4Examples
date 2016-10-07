using System;

namespace LoggingAOP
{
    public class LogAttribute : Attribute
    {
        public LogAttribute(string name)
        {
            Name = name;
        }

        public LogAttribute()
        {
        }

        public string Name { get; private set; }
    }
}