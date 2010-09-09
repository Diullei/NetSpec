using System.Collections.Generic;

namespace NetSpec.Core.Infrastructure
{
    using System;
    using System.Linq;
    using System.Reflection;

    public interface IObjectToBeLoaded
    {}

    public class AssemblyLoader<TInterface> where TInterface : IObjectToBeLoaded
    {
        public static IList<TInterface> GetAll()
        {
            var result = new List<TInterface>();

            // TODO: criar mecanismo que permita configurar o path de localização de assemblies por interface
            var obj = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i == typeof(TInterface))).ToList();

            obj.ForEach(f =>
            {
                var tFramework = (TInterface)Activator.CreateInstance(f);
                result.Add(tFramework);
            });

            return result;
        }
    }

    public class TestFrameworkLoader
    {
        private static ITestFrameworkAdapter _tFramework = null;

        public static ITestFrameworkAdapter Load()
        {
            if (_tFramework == null)
            {
                AssemblyLoader<ITestFrameworkAdapter>.GetAll().ToList().ForEach(f =>
                {
                    if (f.TryLoadFramework())
                    {
                        _tFramework = f;
                    }
                });

                if (_tFramework == null)
                    throw new Exception("Não foi possível carregar um framework de teste.");
            }
            return _tFramework;
        }
    }
}