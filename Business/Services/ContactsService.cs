using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Business.Interfaces;
using Data.Entities;

namespace Business.Services
{
    public class ContactsService
    {
       private HttpClient _httpClient;

        private void SetupClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:53473/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ContactsService()
        {
            SetupClient();
        }

        public IEnumerable<Contact> GetAllContacts(IContacts account)
        {
            return account.GetAllContacts();
        }
        public Contact GetContact(IContacts account, long id)
        {
            return account.GetContact(id);
        }
        public Contact GetContact(IContacts account, string nameOrPhoneNumber)
        {
            return account.GetContact(nameOrPhoneNumber);
        }

        public void NewContactAdded(Contact contact)
        {
            _httpClient.PostAsJsonAsync("api/Contacts", contact);
        }

    }
}
