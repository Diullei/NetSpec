namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public class ByteParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(byte);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToByte(parameter.Value);
        }
    }
}