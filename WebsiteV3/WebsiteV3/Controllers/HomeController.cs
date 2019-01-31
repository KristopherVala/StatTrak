using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using System.Web.Security;
using WebsiteV3.Models;

namespace WebsiteV3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            string pass = "Below is the easiest way to contact us." + System.Environment.NewLine + "Phone lines are available 24/7" +
            System.Environment.NewLine + "Email response is up to two business days.";
            ViewBag.Message = pass;
            return View();
        }

        private Uri RediredtUri
        { 
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
        {
              //  client_id = "414482452330294",
               // client_secret = "943bfdac645b9b7b6a694639361d1b27",
                client_id = "1514982441964348",
                client_secret = "1f51cad66976034a1020469470bdecda",
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                // client_id = "414482452330294",
                // client_secret = "943bfdac645b9b7b6a694639361d1b27",
                 client_id = "1514982441964348",
                 client_secret = "1f51cad66976034a1020469470bdecda",
                redirect_uri = RediredtUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;
            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");
            string email = me.email;   
            TempData["email"] = me.email;
            TempData["first_name"] = me.first_name;
            TempData["lastname"] = me.last_name;
            TempData["picture"] = me.picture.data.url;
            FormsAuthentication.SetAuthCookie(email, false);
            var user = new ApplicationUser { UserName = me.first_name, Email = me.email, FirstName = me.first_name, LastName = me.last_name, ProfileName = me.first_name, ProfilePhoto = me.picture.data.url, Player = null, Role = "User" };

            return RedirectToAction("Index", "Home");
        }
    }
}
   