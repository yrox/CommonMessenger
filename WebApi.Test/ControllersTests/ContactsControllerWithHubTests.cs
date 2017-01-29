using Data.Entities;
using Moq;
using NUnit.Framework;
using Olga.Data;
using WebApi.Controllers;

namespace WebApi.Test.ControllersTests
{
    [TestFixture]
    public class ContactsControllerWithHubTests
    {
        private Mock<UnitOfWork> _unitOfWorkMock;
        private ContactsControllerWithHub _contactsController;

        [SetUp]
        public void SetUp()
        {
            
            _unitOfWorkMock = new Mock<UnitOfWork>();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>()).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Find(It.IsAny<int>())).Returns(new Contact());
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Delete(It.IsAny<Contact>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Insert(It.IsAny<Contact>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Contact>().Update(It.IsAny<Contact>())).Verifiable();

            _contactsController = new ContactsControllerWithHub(_unitOfWorkMock.Object);
        }

        [Test]
        public void Get_ShoudReturnEntity_Succeed()
        {
            var result = _contactsController.Get(1);
            _unitOfWorkMock.Verify(x => x.Repository<Contact>().Find(It.IsAny<int>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<Contact>(result);
        }

        [Test]
        public void Insert_ShouldInsertEntity_Succeed()
        {
            _contactsController.Insert(new Contact());
            _unitOfWorkMock.Verify(x => x.Repository<Contact>(), Times.Once);
        }

        
        [Test]
        public void Update_ShouldUpdatetEntity_Succeed()
        {
            _contactsController.Update(new Contact());
            _unitOfWorkMock.Verify(x => x.Repository<Contact>().Update(It.IsAny<Contact>()), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteEntity_Succeed()
        {
            _contactsController.Delete(new Contact());
            _unitOfWorkMock.Verify(x => x.Repository<Contact>().Delete(It.IsAny<Contact>()), Times.Once);
        }
    }
}

    

