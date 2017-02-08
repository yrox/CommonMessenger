using System.Linq;
using Data.Business.Entities;
using NUnit.Framework;

namespace Data.Business.Tests
{
    [TestFixture]
    public class ContextTests
    {
        private Context _context;

        [SetUp]
        public void Setup()
        {
            _context = new Context();
        }

        [Test]
        public void Contacts_ShouldReturnContacts_Succees()
        {
            var contacts = _context.Contacts;
            Assert.NotNull(contacts);
        }

        [Test]
        public void Contacts_ShouldSetContacts_Succees()
        {
            var contacts = _context.Contacts;
            contacts.Add(new Contact());
            Assert.NotZero(contacts.Local.Count);
            Assert.IsInstanceOf<Contact>(contacts.Local.First());
        }

        [Test]
        public void MetaContacts_ShouldReturnMetaContacts_Succees()
        {
            var contacts = _context.MetaContacts;
            Assert.NotNull(contacts);
        }

        [Test]
        public void MetaContacts_ShouldSetMetaContacts_Succees()
        {
            var contacts = _context.MetaContacts;
            contacts.Add(new MetaContact());
            Assert.NotZero(contacts.Local.Count);
            Assert.IsInstanceOf<MetaContact>(contacts.Local.First());
        }
    }
}
