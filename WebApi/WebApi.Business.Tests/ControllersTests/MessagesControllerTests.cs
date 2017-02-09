using System;
using System.Collections.Generic;
using AutoMapper;
using Data.Business.Entities;
using DTOs;
using Moq;
using NUnit.Framework;
using Olga.Data;
using WebApi.Controllers;
using WebApi.Util;

namespace WebApi.Test.ControllersTests
{
    public class MessagesControllerTests
    {
        private Mock<UnitOfWork> _unitOfWorkMock;
        private MessagesController _messagesController;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(x => x.AddProfile<MapProfile>());

            _unitOfWorkMock = new Mock<UnitOfWork>();
            _unitOfWorkMock.Setup(x => x.Repository<Message>()).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Message>().Find(It.IsAny<int>())).Returns(new Message());
            _unitOfWorkMock.Setup(x => x.Repository<Message>().Delete(It.IsAny<Message>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Message>().Insert(It.IsAny<Message>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Message>().Update(It.IsAny<Message>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Message>().GetAll()).Returns(new List<Message> { new Message() });

            //_messagesController = new MessagesController(_unitOfWorkMock.Object);
        }

        [Test]
        public void GetAll_ShouldReturnEntitiesCol_Succeed()
        {
            var result = _messagesController.GetAll();
            _unitOfWorkMock.Verify(x => x.Repository<Message>().GetAll(), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<MessageDTO>>(result);
        }

        [Test]
        public void Get_ShoudReturnEntity_Succeed()
        {
            var result = _messagesController.Get(1);
            _unitOfWorkMock.Verify(x => x.Repository<Message>().Find(It.IsAny<int>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<MessageDTO>(result);
        }

        [Test]
        public void Insert_ShouldInsertEntity_Succeed()
        {
            _messagesController.Insert(new MessageDTO());
            _unitOfWorkMock.Verify(x => x.Repository<Message>(), Times.Once);
        }


        [Test]
        public void Update_ShouldUpdatetEntity_Succeed()
        {
            var id = new Random().Next();
            _messagesController.Update(new MessageDTO { Id = id });
            _unitOfWorkMock.Verify(x => x.Repository<Message>().Update(It.IsAny<Message>()), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteEntity_Succeed()
        {
            _messagesController.Delete(new MessageDTO());
            _unitOfWorkMock.Verify(x => x.Repository<Message>().Delete(It.IsAny<Message>()), Times.Once);
        }
    }
}
