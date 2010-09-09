namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public class BoolParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(bool);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToBoolean(parameter.Value);
        }
    }
}