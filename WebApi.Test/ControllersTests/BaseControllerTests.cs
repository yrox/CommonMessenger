using Moq;
using NUnit.Framework;
using Olga.Data;
using WebApi.Controllers;

namespace WebApi.Test.ControllersTests
{
    [TestFixture]
    public class BaseEntityControllerTests
    {
        private Mock<UnitOfWork> _unitOfWorkMock;
        private BaseEntityController<Entity> _baseEntityController;

        [SetUp]
        public void SetUp()
        {
            
            _unitOfWorkMock = new Mock<UnitOfWork>();
            _unitOfWorkMock.Setup(x => x.Repository<Entity>()).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Entity>().Find(It.IsAny<int>())).Returns(new Entity());
            _unitOfWorkMock.Setup(x => x.Repository<Entity>().Delete(It.IsAny<Entity>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Entity>().Insert(It.IsAny<Entity>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<Entity>().Update(It.IsAny<Entity>())).Verifiable();

            _baseEntityController = new BaseEntityController<Entity>(_unitOfWorkMock.Object);
        }

        [Test]
        public void Get_ShoudReturnEntity_Succeed()
        {
            var result = _baseEntityController.Get(1);
            _unitOfWorkMock.Verify(x => x.Repository<Entity>().Find(It.IsAny<int>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<Entity>(result);
        }

        [Test]
        public void Insert_ShouldInsertEntity_Succeed()
        {
            _baseEntityController.Insert(new Entity());
            _unitOfWorkMock.Verify(x => x.Repository<Entity>(), Times.Once);
        }

        [Test]
        public void Update_ShouldUpdatetEntity_Succeed()
        {
            _baseEntityController.Update(new Entity());
            _unitOfWorkMock.Verify(x => x.Repository<Entity>().Update(It.IsAny<Entity>()), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteEntity_Succeed()
        {
            _baseEntityController.Delete(new Entity());
            _unitOfWorkMock.Verify(x => x.Repository<Entity>().Delete(It.IsAny<Entity>()), Times.Once);
        }
    }
}
