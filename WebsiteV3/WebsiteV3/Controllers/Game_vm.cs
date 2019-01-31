using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteV3.Controllers
{
    public class GameAdd
    {
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        public int ReleaseDate { get; set; }
        [Display(Name = "")]
        public string Category1 { get; set; }
        [Display(Name = "")]
        public string Category2 { get; set; }
        [Display(Name = "")]
        public string Category3 { get; set; }
        [Display(Name = "")]
        public string Category4 { get; set; }
 
        [Display(Name = "Artwork")]
        [DataType(DataType.Url)]
        public string Art { get; set; }

        [Display(Name = "Artwork")]
        [DataType(DataType.Url)]
        public string AltGameArt { get; set; }

        public string GameBio { get; set; }

    }
    public class GameBase : GameAdd
    {
        public GameBase()
        {
            Genres = new List<GenreBase>();
            GameDatas = new List<GameDataBase>();
            Screenshots = new List<ScreenBase>();

        }
        public int Id { get; set; }
        public IEnumerable<GameDataBase> GameDatas { get; set; }
        public IEnumerable<GenreBase> Genres { get; set; }
        public IEnumerable<ScreenBase> Screenshots { get; set; }
        public string PlayerName { get; set; }
        public string PlayerProfilePhoto { get; set; }

        public string WhereToGet { get; set; }


    }
}