namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public class SByteParameterConvert : IParameterConvert
    {
        public bool Accept(Parameter parameter)
        {
            return parameter.ParameterInfo.ParameterType == typeof(sbyte);
        }

        public object Convert(Parameter parameter)
        {
            return System.Convert.ToSByte(parameter.Value);
        }
    }
}