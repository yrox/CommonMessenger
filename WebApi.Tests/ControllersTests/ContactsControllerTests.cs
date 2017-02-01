using System;
using System.Collections.Generic;
using AutoMapper;
using Data.Entities;
using DTOs;
using Moq;
using NUnit.Framework;
using Olga.Data;
using WebApi.Controllers;

namespace WebApi.Tests.ControllersTests
{
    [TestFixture]
    public class ContactsControllerTests
    {
        private Mock<UnitOfWork> _unitOfWorkMock;
        private ContactsController _contactsController;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(x => x.AddProfile<MapProfile>());

            _unitOfWorkMock = new Mock<UnitOfWork>();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>()).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Find(It.IsAny<int>())).Returns(new Contact());
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Delete(It.IsAny<Contact>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Insert(It.IsAny<Contact>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Update(It.IsAny<Contact>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().GetAll()).Returns(new List<Contact> {new Contact()});

            _contactsController = new ContactsController(_unitOfWorkMock.Object);
        }

        [Test]
        public void GetAll_ShouldReturnEntitiesCol_Succeed()
        {
            var result = _contactsController.GetAll();
            _unitOfWorkMock.Verify(x => x.Repository<Contact>().GetAll(), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<ContactDTO>>(result);
        }

        [Test]
        public void Get_ShoudReturnEntity_Succeed()
        {
            var result = _contactsController.Get(1);
            _unitOfWorkMock.Verify(x => x.Repository<Contact>().Find(It.IsAny<int>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<ContactDTO>(result);
        }

        [Test]
        public void Insert_ShouldInsertEntity_Succeed()
        {
            _contactsController.Insert(new ContactDTO());
            _unitOfWorkMock.Verify(x => x.Repository<Contact>(), Times.Once);
        }

        
        [Test]
        public void Update_ShouldUpdatetEntity_Succeed()
        {
            var id = new Random().Next();
            _contactsController.Update(id, new ContactDTO {Id = id});
            _unitOfWorkMock.Verify(x => x.Repository<Contact>().Update(It.IsAny<Contact>()), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteEntity_Succeed()
        {
            _contactsController.Delete(new ContactDTO());
            _unitOfWorkMock.Verify(x => x.Repository<Contact>().Delete(It.IsAny<Contact>()), Times.Once);
        }
    }
}

    

