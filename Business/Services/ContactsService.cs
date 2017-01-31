using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Business.Interfaces;
using DTOs;

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

        public IEnumerable<ContactDTO> GetAllContacts(IContacts account)
        {
            return account.GetAllContacts();
        }
        public ContactDTO GetContact(IContacts account, long id)
        {
            return account.GetContact(id);
        }
        public ContactDTO GetContact(IContacts account, string nameOrPhoneNumber)
        {
            return account.GetContact(nameOrPhoneNumber);
        }

        public void NewContactAdded(ContactDTO contact)
        {
            _httpClient.PostAsJsonAsync("api/Contacts", contact);
        }

    }
}
