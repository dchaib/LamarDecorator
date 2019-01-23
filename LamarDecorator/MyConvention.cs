using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;
using System.Linq;

namespace LamarDecorator
{
    public class MyConvention : IRegistrationConvention
    {
        private const string CachePrefix = "Cached";

        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {
            var concreteTypes = types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed);
            foreach (var type in concreteTypes)
            {
                var @interface = type.GetInterfaces().FirstOrDefault(t => t.Name == "I" + type.Name);
                if (@interface != null)
                {
                    var cachedType = concreteTypes.FirstOrDefault(t => t.Name.Equals(CachePrefix + type.Name));
                    if (cachedType != null && cachedType.GetInterfaces().Any(t => t.Name == "I" + type.Name))
                    {
                        // There is a version with cache, register this type
                        //services.For(@interface).Use(cachedType).Ctor(@interface).Is(type);
                    }
                    else
                    {
                        // There is no version with cache, register using the standard way
                        services.For(@interface).Use(type);
                    }
                }
            }
        }
    }
}
