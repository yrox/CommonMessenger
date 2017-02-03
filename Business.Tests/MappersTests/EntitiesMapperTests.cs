using System;
using System.Collections.Generic;
using System.Linq;
using Business.Mappers;
using DTOs;
using NUnit.Framework;

namespace Business.Tests.MappersTests
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

        [Test]
        public void Map_ShouldMapMessageDTO_to_VkMessage_Succeed()
        {
            var id = new Random().Next();
            var mesage = EntitiesMapper.Map(new VkNet.Model.Message {UserId = id});
            Assert.NotNull(mesage);
            Assert.IsInstanceOf<MessageDTO>(mesage);
            Assert.AreEqual(id, mesage.AccountId);
        }

        [Test]
        public void Map_ShouldMapEnumerableMessageDTO_to_VkMessage_Succeed()
        {
            var vkMessageEnum = new List<VkNet.Model.Message>().ToList();
            var result = EntitiesMapper.Map(vkMessageEnum);
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<MessageDTO>>(result);
        }

        [Test]
        public void Map_ShouldMapMessageDTO_to_TlMessage_Succeed()
        {
            var id = new Random().Next();
            var mesage = EntitiesMapper.Map(new TeleSharp.TL.TLMessage {from_id = id});
            Assert.NotNull(mesage);
            Assert.IsInstanceOf<MessageDTO>(mesage);
            Assert.AreEqual(id, mesage.AccountId);
        }

        [Test]
        public void Map_ShouldMapEnumerableMessageDTO_to_TlMessage_Succeed()
        {
            var tlMessageEnum = new List<TeleSharp.TL.TLMessage>().ToList();
            var result = EntitiesMapper.Map(tlMessageEnum);
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<MessageDTO>>(result);
        }
    }
}
