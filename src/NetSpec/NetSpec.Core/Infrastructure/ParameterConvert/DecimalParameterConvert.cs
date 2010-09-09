namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public class DecimalParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(decimal);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToDecimal(parameter.Value);
        }
    }
}