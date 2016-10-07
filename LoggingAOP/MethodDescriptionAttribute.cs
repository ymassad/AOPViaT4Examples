using System;

namespace LoggingAOP
{
    public class MethodDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public MethodDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
