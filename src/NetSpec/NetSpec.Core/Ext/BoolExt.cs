namespace NetSpec.Core.Ext
{
    using System;

    public static class BoolExt
    {
        #region " Métodos "

        public static void ExecuteIfIsTrue(this bool b, Action action)
        {
            if (b)
            {
                action.Invoke();
            }
        }

        #endregion
    }
}