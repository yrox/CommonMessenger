using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace Business.Tests.ServicesTests
{
    [TestFixture]
    public class ContactsServiceTests//TODO
    {
        [Test]
        public async void NewContactAdded_ShouldPostContact_Succeed()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53473/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var resp = await client.PostAsJsonAsync()
        }
    }
}
