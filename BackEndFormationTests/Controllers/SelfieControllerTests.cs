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
            Selfie selfie = new() { Id = 1, Title = "title 1", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } };
            //Act
            var controller = new SelfieController(mockRepository.Object);
            var result = controller.AddOne(selfie);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            OkObjectResult? okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult?.Value);
            Assert.IsInstanceOfType<SelfieDto>(okResult.Value);
            SelfieDto? addedSelfie = okResult.Value as SelfieDto;
            Assert.IsNotNull(addedSelfie);
            Assert.IsTrue(addedSelfie.Id > 0);
        }

        [TestMethod()]
        public void ShouldReturnListOfSelfies()
        {
            //arrange
            var expectedList = new List<Selfie>()
            {
                new Selfie {Id = 1, Title = "title 1", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } },
                new Selfie {Id = 2, Title = "title 2", Wookie = new Wookie { Id = 1, Surname = "wookie 1" } }
            };

            Mock<ISelfieRepository> repositoryMock = new();
            repositoryMock.Setup(item => item.GetAll()).Returns(expectedList);
            var controller = new SelfieController(repositoryMock.Object);

            //act
            var result = controller.Get();

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult? okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult?.Value);
            Assert.IsInstanceOfType<List<SelfieResumeDto>>(okResult?.Value);

            List<SelfieResumeDto>? list = okResult.Value as List<SelfieResumeDto>;
            Assert.IsTrue(list?.Count == expectedList.Count);
        }
        #endregion
    }
}