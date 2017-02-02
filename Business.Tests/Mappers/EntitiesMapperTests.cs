using System;
using Business.Mappers;
using DTOs;
using NUnit.Framework;

namespace Business.Tests.Mappers
{
    [TestFixture]
    public class EntitiesMapperTests
    {
        [Test]
        public void Map_ShouldMapContactDTO_to_VkContact_Succeed()
        {
            var id = new Random().Next();
            var contact = EntitiesMapper.Map(new VkNet.Model.User {Id = id, FirstName = "some", LastName = "name"});
            Assert.NotNull(contact);
            Assert.IsInstanceOf<ContactDTO>(contact);
            Assert.AreEqual(id, contact.AccountId);
            Assert.AreEqual("some name", contact.Name);

        }

        [Test]
        public void Map_ShouldMapContactDTO_to_TlContact_Succeed()
        {
            var id = new Random().Next();
            var contact = EntitiesMapper.Map(new TeleSharp.TL.TLUser {id = id, first_name = "some", last_name = "name"});
            Assert.NotNull(contact);
            Assert.IsInstanceOf<ContactDTO>(contact);
            Assert.AreEqual(id, contact.AccountId);
            Assert.AreEqual("some name", contact.Name);

        }
    }
}
