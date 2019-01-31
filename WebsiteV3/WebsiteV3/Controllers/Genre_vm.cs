using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteV3.Controllers
{
    public class GenreAdd
    {
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
    public class GenreBase : GenreAdd
    {
        public int Id { get; set; }
    }
}