using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NetSpec.Core.Ext;
using NetSpec.Core.Infrastructure;

namespace NetSpec.Core
{
    public class MethodSpec
    {
        public MethodInfo MethodInfo { get; private set; }

        public string MethodPatternName { get; private set; }

        public IList<ParameterInfo> ParameterCollection { get; set; }

        public IList<ParameterConvertAttribute> ConvertAttributeCollection { get; set; }

        public MethodSpec(MethodInfo methodInfo)
        {
            MethodInfo = methodInfo;

            var methodName = methodInfo.Name.Replace("_", "(.*)");
            MethodPatternName = methodName.RemoveAccents().SplitCamelCase();

            ParameterCollection = methodInfo.GetParameters().ToList();
            ConvertAttributeCollection = methodInfo.GetAttributes<ParameterConvertAttribute>();
        }

        //public string ApplayConvert(string value)
        //{
        //    ConvertAttributeCollection.ToList().ForEach(a =>
        //        {
        //            for (var i = 0; i < ParameterCollection.Count; i++)
        //            {
        //                if (ParameterCollection[i].ParameterType == a.TargetType)
        //                {
        //                    var convert = (IPConvert)Activator.CreateInstance(a.ConvertClass);

        //                    value = convert.Applay(ParameterCollection[i].ParameterType, value);
        //                }
        //            }
        //        });

        //    return value;
        //}
    }
}
