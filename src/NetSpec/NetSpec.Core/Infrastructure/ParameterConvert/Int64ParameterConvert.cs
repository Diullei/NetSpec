namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    using System;

    public class Int64ParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(Int64);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToInt64(parameter.Value);
        }
    }
}