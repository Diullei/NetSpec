namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    using System;

    public class SingleParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(Single);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToSingle(parameter.Value);
        }
    }
}