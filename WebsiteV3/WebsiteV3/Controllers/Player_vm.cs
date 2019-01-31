using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteV3.Controllers
{
    public class PlayerAdd
    {
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        [Required]
        [Display(Name = "Profile Photo")]
      //  [DataType(DataType.Url)]
        public string ProfilePhoto { get; set; }

        [Display(Name = "Last Login")]
        public string LastLoginDate { get; set; }
    }


        public class PlayerBase : PlayerAdd
        {
            public int Id { get; set; }
            [Display(Name = "Vehicle Photo")]
            public string PhotoUrl
            {
                get
                {
                    return $"/photo/{Id}";
                }
            }
        public string gameName { get; set; }
        }
    
    public class PlayerView : PlayerBase
    {
        public PlayerView()
        {
            GameDatas = new List<GameDataBase>();
            Games = new List<GameBase>();

        }
        public IEnumerable<GameDataBase> GameDatas { get; set; }
        public IEnumerable<GameBase> Games { get; set; }



    }


}
