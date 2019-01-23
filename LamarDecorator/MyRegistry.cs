using Lamar;

namespace LamarDecorator
{
    public class MyRegistry : ServiceRegistry
    {
        public MyRegistry()
        {
            Scan(_ =>
            {
                _.TheCallingAssembly();
                _.Convention<MyConvention>();
            });
        }
    }
}
