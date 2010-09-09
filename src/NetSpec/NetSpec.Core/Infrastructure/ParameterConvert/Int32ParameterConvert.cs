namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    using System;

    public class Int32ParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof (Int32);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToInt32(parameter.Value);
        }
    }
}