namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public class StringParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(string);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToString(parameter.Value);
        }
    }
}