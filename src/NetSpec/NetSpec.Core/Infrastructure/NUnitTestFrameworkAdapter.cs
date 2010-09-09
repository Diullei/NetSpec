using System;
using System.Reflection;

namespace NetSpec.Core.Infrastructure
{
    public class NUnitTestFrameworkAdapter : ITestFrameworkAdapter
    {
        public void Fail()
        {
            var type = Assembly.Load("nunit.framework").GetType("NUnit.Framework.Assert");
            type.GetMethod("Fail", new Type[] { }).Invoke(null, null);
        }

        public void Inconclusive()
        {
            var type = Assembly.Load("nunit.framework").GetType("NUnit.Framework.Assert");
            type.GetMethod("Inconclusive", new Type[] { }).Invoke(null, null);
        }

        public bool TryLoadFramework()
        {
            try
            {
                var type = Assembly.Load("nunit.framework");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}