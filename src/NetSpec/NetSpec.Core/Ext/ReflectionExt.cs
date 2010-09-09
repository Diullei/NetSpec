using System.Collections.Generic;
using System.Linq;

namespace NetSpec.Core.Ext
{
    using System;
    using System.Reflection;

    static class ReflectionExt
    {
        #region " Métodos "

        public static IList<T> GetAttributes<T>(this MethodInfo methodInfo) where T : Attribute
        {
            var result = new List<T>();
            var attrs = System.Attribute.GetCustomAttributes(methodInfo);

            result.AddRange(attrs.OfType<T>());
            return result;
        }

        #endregion
    }
}
