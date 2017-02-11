using System.Web.Http;
using NUnit.Framework;

namespace WebApi.Test.App_StartTests
{
    [TestFixture]
    public class WebApiConfigTests
    {
        [Test]
        public void Register_ShouldMapRoutes_Succeed()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            Assert.NotZero(config.Routes.Count);
        }
    }
}
