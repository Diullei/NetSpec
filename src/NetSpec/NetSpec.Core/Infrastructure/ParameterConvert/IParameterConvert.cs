namespace NetSpec.Core.Infrastructure.ParameterConvert
{
    public interface IParameterConvert
    {
        bool Accept(Parameter parameter);
        object Convert(Parameter parameter);
    }
}