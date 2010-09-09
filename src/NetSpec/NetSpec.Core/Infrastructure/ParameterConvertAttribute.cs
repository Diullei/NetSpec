namespace NetSpec.Core.Infrastructure
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ParameterConvertAttribute : Attribute
    {
        public Type TargetType { get; set; }
        public Type ConvertClass { get; set; }

        public ParameterConvertAttribute(Type targetType, Type convertClass)
        {
            TargetType = targetType;
            ConvertClass = convertClass;
        }
    }
}
