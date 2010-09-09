namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    using System;

    public class UInt32ParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(UInt32);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToUInt32(parameter.Value);
        }
    }
}