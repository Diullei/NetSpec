namespace NetSpec.Core.Infrastructure
{
    using System;
    using System.Reflection;

    public class MsTestFrameworkAdapter : ITestFrameworkAdapter
    {
        public void Fail()
        {
            var type = Assembly.Load("Microsoft.VisualStudio.QualityTools.UnitTestFramework").GetType("Microsoft.VisualStudio.TestTools.UnitTesting.Assert");
            type.GetMethod("Fail", new Type[] { }).Invoke(null, null);
        }

        public void Inconclusive()
        {
            var type = Assembly.Load("Microsoft.VisualStudio.QualityTools.UnitTestFramework").GetType("Microsoft.VisualStudio.TestTools.UnitTesting.Assert");
            type.GetMethod("Inconclusive", new Type[] { }).Invoke(null, null);
        }

        public bool TryLoadFramework()
        {
            try
            {
                var type = Assembly.Load("Microsoft.VisualStudio.QualityTools.UnitTestFramework");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}