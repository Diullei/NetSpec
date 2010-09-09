namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    using System;

    public class Int16ParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(Int16);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToInt16(parameter.Value);
        }
    }
}