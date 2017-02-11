using System.Linq;
using Dialog.Data.Entities;
using Dialog.Data.EntityFramewrk;
using NUnit.Framework;

namespace Dialog.Data.Tests
{
    [TestFixture]
    public class ContextTests
    {
        private DialogDbContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new DialogDbContext();
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
