using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEndFormation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Controllers.Tests
{
    [TestClass()]
    public class SelfieControllerTests
    {
        #region public methods
        [TestMethod()]
        public void ShouldReturnLisOfSelfies()
        {
            //arrange
            var controller = new SelfieController();

            //act
            var result = controller.Get();

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetEnumerator().MoveNext());
        }
        #endregion
    }
}