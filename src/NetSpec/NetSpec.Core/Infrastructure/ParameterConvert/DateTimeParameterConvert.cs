namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    using System;

    public class DateTimeParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(DateTime);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToDateTime(parameter.Value);
        }
    }
}