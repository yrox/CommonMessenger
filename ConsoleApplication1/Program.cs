using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace ConsoleApplication1
{
    class Program
    {
        public static async void Test()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53473/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var resp = await client.PutAsJsonAsync("api/contacts", new ContactDTO());
            resp.EnsureSuccessStatusCode();
        }
        static void Main(string[] args)
        { 
            Test();
        }
    }
}
