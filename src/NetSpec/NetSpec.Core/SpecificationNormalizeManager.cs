using System.Linq;
using NetSpec.Core.Infrastructure;

namespace NetSpec.Core
{
    public class SpecificationNormalizeManager
    {
        public void Normalize(Specification specification)
        {
            AssemblyLoader<ISpecificationNormalize>.GetAll().ToList().ForEach(s => s.DoNormalize(specification));
        }
    }
}