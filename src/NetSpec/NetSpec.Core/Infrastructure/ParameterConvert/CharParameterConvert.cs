namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public class CharParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(char);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToChar(parameter.Value);
        }
    }
}