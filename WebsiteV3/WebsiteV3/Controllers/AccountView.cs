using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteV3.Controllers
{
    public class UserView 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileName { get; set; }
        public int PlayerId { get; set; }


    }

}