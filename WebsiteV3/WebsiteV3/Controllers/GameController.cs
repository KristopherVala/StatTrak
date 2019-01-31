using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebsiteV3.Models;
namespace WebsiteV3.Controllers
{
    public class GameController : Controller
    {
        private Manager m = new Manager();

        [Authorize]
        public ActionResult Edit(int? id, int? idd, string name)
        {
            var x = m.DataGetById(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                var a = m.GameById(idd.GetValueOrDefault());
                x.Category1 = a.Category1;
                x.Category2 = a.Category2;
                x.Category3 = a.Category3;
                x.Category4 = a.Category4;
                x.GameName = a.Name;
                x.PlayerName = name;
                var editForm = m.mapper.Map<GameDataBase>(x);
              

                return View(editForm);
            }
        }

        [HttpPost]
        public ActionResult Edit(int? id, GameDataBase newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.GameId });
            }

            var x = m.GameStats(id.GetValueOrDefault());

            // Attempt to do the update
            newItem.UploadDate = DateTime.Now.ToString("MMMM dd, yyyy, HH:mm");
            var editedItem = m.DataEdit(newItem);
            if (editedItem == null)
            {        
               return RedirectToAction("edit", new { id = newItem.GameId});
            }
            else
            {
                return RedirectToAction("details", new { id = newItem.GameId });
            }
        }
        // GET: Game
        public ActionResult Index()
        {
            var x = m.GameGetAll();
            return View(x);
        }

        //get player name
        public ActionResult GetPlayer(string name)
        {
            var x = m.PlayerByName(name);
            return View(x);
        }


        // GET: Game/Details/5

        public ActionResult Details(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
           } 
        }

        public ActionResult GameById(int? id)
        {
            var o = m.GameById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }
   

        //filter results
        public ActionResult Sort1(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {                
                return View(x);
            }
        }
        public ActionResult Sort2(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        public ActionResult Sort3(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        public ActionResult Sort4(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        public ActionResult Sort5(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        //filter results ascending
        //filter results
        public ActionResult Sort1a(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        public ActionResult Sort2a(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        public ActionResult Sort3a(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        public ActionResult Sort4a(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }
        public ActionResult Sort5a(int? id)
        {
            var x = m.GameStats(id.GetValueOrDefault());
            if (x == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(x);
            }
        }






        // GET: Game/Create

        [Authorize]
        public ActionResult AddData(int? id)
        {
            var a = m.GameById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
 
                var o = new GameDataBase();
                o.Category1 = a.Category1;
                o.Category2 = a.Category2;
                o.Category3 = a.Category3;
                o.Category4 = a.Category4;
                o.GameName = a.Name;
                o.GameId = a.Id;
                o.GameArt = a.Art;
                return View(o);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddData(GameDataBase newItem)
        {
            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());

            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            newItem.UploadDate = DateTime.Now.ToString("MMMM dd, yyyy, HH:mm");
            newItem.PlayerName = currentUser.ProfileName;
          //  newItem.Players = m.PlayerGetId(newItem.PlayerName);
            var addedItem = m.DataAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
              return RedirectToAction("details", new { id = newItem.GameId });
            }
        }


    }
}
