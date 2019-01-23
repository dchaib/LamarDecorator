using System;

namespace LamarDecorator
{
    public interface IService1 { }

    public class Service1 : IService1 { }

    public interface IService2 { }

    public class Service2 : IService2 { }

    public class CachedService2 : IService2
    {
        public IService2 Inner { get; }

        public CachedService2(IService2 service2) => Inner = service2;
    }
}
