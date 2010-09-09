using System.Linq;
using NetSpec.Core.Ex;
using NetSpec.Core.Ext;

namespace NetSpec.Core
{
    public class SpecificationBuilder
    {
        public static Specification Builder(string specification)
        {
            if (specification == null)
                throw new NullSpecificationException();

            var instance = new Specification
                               {
                                   LineSpecCollection =
                                       specification.MultiLineAsList().ToList().Select(line => new LineSpec(line)).
                                       ToList()
                               };

            new SpecificationNormalizeManager().Normalize(instance);

            return instance;
        }
    }
}
