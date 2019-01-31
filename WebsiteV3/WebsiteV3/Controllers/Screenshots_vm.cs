using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteV3.Controllers
{
    public class ScreenBase
    {
        public int Id;
        public int GameId { get; set; }

        [DataType(DataType.Url)]
        public string Screenshot;

    }
}