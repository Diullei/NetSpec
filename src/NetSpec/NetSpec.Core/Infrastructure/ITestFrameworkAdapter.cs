namespace NetSpec.Core.Infrastructure
{
    public interface ITestFrameworkAdapter : IObjectToBeLoaded
    {
        void Fail();
        void Inconclusive();
        bool TryLoadFramework();
    }
}
