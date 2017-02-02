using System;
using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public void Map_ShouldMapEnumerableContactDTO_to_TlContact_Succeed()
        {
            var tlContactEnum = new List<TeleSharp.TL.TLUser>().ToList();
            var result = EntitiesMapper.Map(tlContactEnum);
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<ContactDTO>>(result);
        }

        [Test]
        public void Map_ShouldMapEnumerableContactDTO_to_VkContact_Succeed()
        {
            var vkContactEnum = new List<VkNet.Model.User>().ToList();
            var result = EntitiesMapper.Map(vkContactEnum);
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<ContactDTO>>(result);
        }
    }
}
