using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteV3.Controllers
{
    public class LoadController : Controller
    {
        Manager m = new Manager();

        public ActionResult Add()
        {
            if (m.LoadData())
            {
                return Content("Data has been loaded");
            }
            else
            {
                return Content("Data failed to load ");
            }

        }

        public ActionResult Remove()
        {
            if (m.RemoveDatabase())
            {
                return Content("data has been removed");
            }
            else
            {
                return Content("could not remove data");
            }
        }
    }
}
