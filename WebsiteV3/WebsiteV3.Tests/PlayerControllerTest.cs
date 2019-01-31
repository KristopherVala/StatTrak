using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebsiteV3;
using WebsiteV3.Controllers;

namespace WebsiteV3.Tests
{
    [TestClass]
    public class PlayerControllerTest 
    {
        [TestMethod]
        public void TestIndexView()
        {
            var controller = new PlayerController();
            var result = controller.Index() as ViewResult;
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new PlayerController();
            var result = controller.Details(1) as ViewResult;
            
          // Assert.AreEqual("Details", result.ViewName);

        }


    }
}
