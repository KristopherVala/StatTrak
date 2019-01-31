using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebsiteV3.Models;

namespace WebsiteV3.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private Manager m = new Manager();

        // GET: User
        public ActionResult Index()
        {
            var x = m.PlayerGetAll();
            return View(x);
        }
        public ActionResult Player(string name)
        {
            var x = m.PlayerGetId(name);
            var p = m.PlayerById(x.Id);
            p.GameDatas = m.DataTest(x.DisplayName);
            return View("Details",p);
        }
        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            var x = m.PlayerById(id.GetValueOrDefault());
             x.GameDatas = m.DataTest(x.DisplayName);
            return View(x);
        }
        //testerrrrr
        [Authorize]
        public ActionResult Edit(int? id, int? idd, string name)
        {
            var x = m.PlayerById(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {

                //   var editForm = m.mapper.Map<GameDataBase>(x);
                var editForm = x;


                return View(editForm);
            }
        }
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Edit(int? id, PlayerBase newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.Id});
            }

            var x = m.GameStats(id.GetValueOrDefault());

            // Attempt to do the update
           // newItem.UploadDate = DateTime.Now.ToString("MMMM dd, yyyy, HH:mm");
            var editedItem = m.PlayerEdit(newItem);
           
                if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = newItem.Id });
            }
        }
    }
}
