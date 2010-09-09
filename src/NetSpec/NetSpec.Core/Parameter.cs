using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NetSpec.Core.Infrastructure.ParameterConvert;

namespace NetSpec.Core
{
    public class Parameter
    {
        public string Value { get; set; }
        public ParameterInfo ParameterInfo { get; set; }
        public bool WasConverted { get; set; }

        public Parameter(string value, ParameterInfo parameterInfo)
        {
            Value = value;
            ParameterInfo = parameterInfo;
        }

        public static Parameter Create(string value, ParameterInfo parameterInfo)
        {
            return new Parameter(value, parameterInfo);
        }

        public object TryConvert(IList<Type> customConvert)
        {
            object result = null;
            var convetTypes = Assembly.GetExecutingAssembly().GetTypes().ToList()
                .Where(t => t.GetInterfaces().Any(i => i == typeof (IParameterConvert))).ToList();

            convetTypes.InsertRange(0, customConvert);

            convetTypes.ForEach(tc =>
                                    {
                                        var c = (IParameterConvert) Activator.CreateInstance(tc);
                                        if (!WasConverted)
                                        {
                                            if (c.Accept(this))
                                            {
                                                result = c.Convert(this);
                                                WasConverted = true;
                                            }
                                        }
                                    });
            if (!WasConverted)
                throw new Exception(string.Format("Não foi possível realizar a conversão do parâmetro para o tipo: {0}", ParameterInfo.ParameterType));

            return result;
        }
    }
}
