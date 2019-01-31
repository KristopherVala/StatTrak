using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebsiteV3.Controllers
{
    public class GameDataBase
    {
        public int Id { get; set; }
        public float Data1 { get; set; }
        public float Data2 { get; set; }
        public float Data3 { get; set; }
        public float Data4 { get; set; }


        public string GameName { get; set; }

        [DataType(DataType.Url)]
        public string GameArt { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }

        public string GameCategory1 { get; set; }
        public string GameCategory2 { get; set; }
        public string GameCategory3 { get; set; }
        public string GameCategory4 { get; set; }
        public int GameId { get; set; }
        public SelectList GameList { get; set; }

        [Display(Name = "Upload Date")]
        public string UploadDate { get; set; }

        public GameDataBase(){
          Players = new List<PlayerBase>();
            }
        public IEnumerable<PlayerBase> Players { get; set; }

        public string PlayerName { get; set; }

    }
}