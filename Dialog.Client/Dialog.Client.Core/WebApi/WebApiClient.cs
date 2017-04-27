using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Dialog.Client.DTO.Interfaces;
using Newtonsoft.Json;

namespace Dialog.Client.Core.WebApi
{
    public class WebApiClient<T> where T : IManageableResource
    {
        private readonly string _resource;
        private readonly HttpClient _httpClient;

        public WebApiClient(string resource)
        {
            _resource = resource;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:53473/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<T> GetAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(_httpClient.GetAsync($"api/{_resource}").Result.Content.ToString());
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        { }

        public T Find(int id)
        {
            return JsonConvert.DeserializeObject<T>(_httpClient.GetAsync($"api/{_resource}/{id}").Result.Content.ToString());
        }

        public void Add(T item)
        {
            _httpClient.PostAsJsonAsync($"api/{_resource}", item);
        }

        public void Update(T item)
        {
            _httpClient.PutAsJsonAsync($"api/{_resource}", item);
        }

        public void Delete(int id)
        {
            _httpClient.DeleteAsync($"api/{_resource}/{id}");
        }
    }
}
