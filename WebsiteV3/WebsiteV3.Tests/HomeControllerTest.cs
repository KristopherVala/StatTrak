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
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
        }

     


    }
}
