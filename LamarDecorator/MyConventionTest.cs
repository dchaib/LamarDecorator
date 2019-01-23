using Lamar;
using Xunit;

namespace LamarDecorator
{
    public class MyConventionTest
    {
        [Fact]
        public void Service1_Is_Registered()
        {
            var container = new Container(new MyRegistry());
            Assert.IsType<Service1>(container.GetInstance<IService1>());
        }

        [Fact]
        public void Service2_Is_Decorated()
        {
            var container = new Container(new MyRegistry());
            Assert.IsType<CachedService2>(container.GetInstance<IService2>());
        }

        [Fact]
        public void CachedService2Inner_Is_Service2()
        {
            var container = new Container(new MyRegistry());
            Assert.IsType<Service2>(((CachedService2)container.GetInstance<IService2>()).Inner);
        }
    }
}
