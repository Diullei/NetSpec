namespace NetSpec.Core.Ext
{
    using System;

    static class ObjectExt
    {
        #region " Métodos "

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static void IfIsNullThrow<T>(this object obj) where T: Exception, new()
        {
            if(obj == null)
                throw new T();
        }

        //public static T CheckNullAndReturnValue<T, TException>(this T obj) where TException: Exception, new()
        //{
        //    obj.IfIsNullThrow<TException>();
        //    return obj;
        //}

        #endregion
    }
}