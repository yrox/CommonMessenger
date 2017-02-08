using System.Collections.Generic;
using System.Linq;
using Data.Business.Entities;
using NUnit.Framework;

namespace Data.Business.Tests.EntitiesTests
{
    [TestFixture]
    public class MetaContactTests
    {
        private MetaContact _contact = new MetaContact();

        [Test]
        public void Contacts_ShouldGetSetValue_Succeed()
        {
            var contact = new Contact();
            _contact.Contacts = new List<Contact> {contact};
            Assert.NotNull(_contact.Contacts);
            Assert.NotZero(_contact.Contacts.Count());
            Assert.AreEqual(contact, _contact.Contacts.First());
        }

    }
}
