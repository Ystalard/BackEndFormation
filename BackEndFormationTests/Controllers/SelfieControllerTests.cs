using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEndFormation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndFormation.Core.Selfies.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using BackEndFormation.Application.DTOs;
using Xunit;
using BackEndFormation.Core.FrameWork;

namespace BackEndFormation.Controllers.Tests
{
    [TestClass()]
    public class SelfieControllerTests
    {
        #region public methods
        [TestMethod()]
        public void ShouldAddOneSelfie()
        {
            //Arrange
            Mock<ISelfieRepository> mockRepository = new();
            Mock<IUnitOfWork> UnitOfWork = new();

            mockRepository.Setup(item => item.UnitOfWork).Returns(UnitOfWork.Object);

            var expectedList = new List<Selfie>()
            {
                new() {Id = 1, Title = "title 1", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } },
                new() {Id = 2, Title = "title 2", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } }
            };
            mockRepository.Setup(item => item.GetAll(null)).Returns(expectedList);
            mockRepository.Setup(item => item.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() { Id = expectedList.Max(item => item.Id) + 1, Title = "title", Wookie = new() { Id = 5, Surname = "wookieSurname"}, ImagePath = "imagePath"  });
            SelfieDto expectedSelfieDto = new() { Title = "title 1", ImagePath = "imagePath", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } };
            //Act
            var controller = new SelfieController(mockRepository.Object);
            var result = controller.AddOne(expectedSelfieDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            OkObjectResult? okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult?.Value);
            Assert.IsInstanceOfType<SelfieDto>(okResult.Value);
            SelfieDto? addedSelfieDto = okResult.Value as SelfieDto;
            Assert.IsNotNull(addedSelfieDto);
            Assert.IsTrue(addedSelfieDto.Id == expectedList.Max(item => item.Id) + 1 && addedSelfieDto.Title == expectedSelfieDto.Title && addedSelfieDto.Wookie.Id == expectedSelfieDto.Wookie.Id);
        }

        [TestMethod()]
        public void ShouldReturnListOfSelfies()
        {
            //arrange
            var expectedList = new List<Selfie>()
            {
                new() {Id = 1, Title = "title 1", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } },
                new() {Id = 2, Title = "title 2", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } }
            };

            Mock<ISelfieRepository> repositoryMock = new();
            repositoryMock.Setup(item => item.GetAll(null)).Returns(expectedList);
            var controller = new SelfieController(repositoryMock.Object);

            //act
            var result = controller.GetAll(null);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult? okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult?.Value);
            Assert.IsInstanceOfType<List<SelfieResumeDto>>(okResult?.Value);

            List<SelfieResumeDto>? list = okResult.Value as List<SelfieResumeDto>;
            Assert.IsTrue(list?.Count == expectedList.Count);
        }

        [TestMethod()]
        public void ShouldReturnListOfSelfiesRelatedToOneWookie()
        {
            //arrange
            int expectedId = 1;
            var expectedList = new List<Selfie>()
            {
                new() {Id = 1, Title = "title 1", Wookie = new Wookie { Id = expectedId, Surname = "wookie 1" } },
                new() {Id = 2, Title = "title 2", Wookie = new Wookie { Id = expectedId, Surname = "wookie 1" } }
            };

            Mock<ISelfieRepository> repositoryMock = new();
            repositoryMock.Setup(item => item.GetAll(1)).Returns(expectedList);
            var controller = new SelfieController(repositoryMock.Object);

            //act
            var result = controller.GetAll(1);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult? okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult?.Value);
            Assert.IsInstanceOfType<List<SelfieResumeDto>>(okResult?.Value);

            List<SelfieResumeDto>? list = okResult.Value as List<SelfieResumeDto>;
            Assert.IsTrue(list?.Count == expectedList.Count && list.All(item => item.WookieId == expectedId));
        }
        #endregion
    }
}