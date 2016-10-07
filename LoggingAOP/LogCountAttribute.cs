using System;

namespace LoggingAOP
{
    public class LogCountAttribute : Attribute
    {
        public LogCountAttribute(string name)
        {
            Name = name;
        }

        public LogCountAttribute()
        {
        }

        public string Name { get; private set; }
    }
}