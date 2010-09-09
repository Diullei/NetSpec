namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public class DoubleParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(double);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToDouble(parameter.Value);
        }
    }
}