using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebsiteV3.Controllers;

namespace WebsiteV3.Models
{
  
    public class Game
    {
        public Game()
        {
            ReleaseDate = DateTime.Now.Year;
            GameDatas = new List<GameData>();
            ScreenShots = new List<Screenshots>();
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public int ReleaseDate { get; set; }

        [Required, StringLength(100)]
        public string Category1 { get; set; }
        [Required, StringLength(100)]
        public string Category2 { get; set; }
        [Required, StringLength(100)]
        public string Category3 { get; set; }
        [Required, StringLength(100)]
        public string Category4 { get; set; }

        public Genre Genre { get; set; }

        [Required, StringLength(100)]
        public string GameBio { get; set; }

        [Required, StringLength(200)]
        public string Art { get; set; }

        [StringLength(200)]
        public string AltGameArt { get; set; }

        public ICollection<GameData> GameDatas { get; set; }
        public ICollection<Screenshots> ScreenShots { get; set; }

        public string WhereToGet { get; set; }



    }
    public class GameData
    {
        
        public GameData() {
            UploadDate = DateTime.Now.Year.ToString("MMMM DD, YYYY, HH mm");
        }
        public int Id { get; set; }
        public float Data1 { get; set; }
        public float Data2 { get; set; }
        public float Data3 { get; set; }
        public float Data4 { get; set; }

        [Required]
        public Game Game { get; set; }

        public string UploadDate { get; set;}
        public Player Player { get; set; }
        public string PlayerName { get; set; }


    }
   
    public class Genre
    {
        public Genre()
        {
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string GenreName { get; set; }
    }
    public class Screenshots
    {
        public int Id { get; set; }

        [Required]
        public Game Game { get; set; }

        public string Screenshot { get; set; }
    }

    public class Player
    {
        public Player()
        {
            GameDatas = new List<GameData>();
        }
      //  public virtual ICollection<UserProfile> Attendees { get; set; }

        public ICollection<GameData> GameDatas { get; set; }

        public Game Game { get; set; }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string DisplayName { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        public int Age { get; set; }

       
        [Required, StringLength(10)]
        public string Role { get; set; }

        public string ProfilePhoto { get; set; }

        [StringLength(200)]
        public string PhotoContentType { get; set; }
        public byte[] Photo { get; set; }

        public string LastLoginDate { get; set; }

      
    }

}