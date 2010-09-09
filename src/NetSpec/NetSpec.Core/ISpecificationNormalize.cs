using NetSpec.Core.Infrastructure;

namespace NetSpec.Core
{
    public interface ISpecificationNormalize : IObjectToBeLoaded
    {
        void DoNormalize(Specification specification);
    }
}