using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebsiteV3.Models;
using System.Data.Entity.Validation;

namespace WebsiteV3.Controllers
{
    public class Manager
    {
        private ApplicationDbContext ds = new ApplicationDbContext();

        MapperConfiguration config;
        public IMapper mapper;

        public Manager()
        {
            config = new MapperConfiguration(cfg =>
            {

            cfg.CreateMap<Models.Player, Controllers.PlayerBase>();
            cfg.CreateMap<Models.Genre, Controllers.GenreBase>();
            cfg.CreateMap<Models.Game, Controllers.GameBase>();
            cfg.CreateMap<Controllers.GenreBase, Controllers.GameBase>();
            cfg.CreateMap<Models.GameData, Controllers.GameDataBase>();
            cfg.CreateMap<Models.Game, Controllers.GameAdd>();
            cfg.CreateMap<Controllers.GameDataBase, Models.GameData>();
            cfg.CreateMap<Models.Screenshots, Controllers.ScreenBase>();
            cfg.CreateMap<Models.Player, Controllers.PlayerView>();
                cfg.CreateMap<Controllers.ScreenBase, Controllers.GameBase>();
                cfg.CreateMap<Controllers.PlayerAdd, Models.Player>();



            });
            mapper = config.CreateMapper();
            ds.Configuration.ProxyCreationEnabled = false;
            ds.Configuration.LazyLoadingEnabled = false;
        }


        public IEnumerable<GameBase> GameGetAll()
        {
            return mapper.Map<IEnumerable<GameBase>>(ds.Games.OrderBy(a => a.Name));
        }

        public IEnumerable<GenreBase> GenreGetAll()
        {
            return mapper.Map<IEnumerable<GenreBase>>(ds.Genres);
        }

        public IEnumerable<PlayerBase> PlayerGetAll()
        {
            return mapper.Map<IEnumerable<PlayerBase>>(ds.Players);
        }

       public PlayerBase PlayerAdd(PlayerAdd newItem)
       {

            var addedItem = ds.Players.Add(mapper.Map<Player>(newItem));
            ds.SaveChanges();
            return (addedItem == null) ? null : mapper.Map<PlayerBase>(addedItem);
        }
        public PlayerView PlayerById(int id)
        {
            var x = ds.Players.SingleOrDefault(t => t.Id == id);
            return (x == null) ? null : mapper.Map<PlayerView>(x);
        }

        public Player GetId(string name)
        {
            var o = ds.Players.SingleOrDefault(x => x.DisplayName == name);
            return (o == null) ? null : mapper.Map<Player>(o);

        }

        public PlayerBase PlayerByName(string name)
        {
            var x = ds.Players.SingleOrDefault(t => t.DisplayName == name);
            return (x == null) ? null : mapper.Map<PlayerBase>(x);
        }

        public PlayerBase PlayerGetId(string name)
        {
            var x = ds.Players.SingleOrDefault(t => t.DisplayName == name);
            return (x == null) ? null : mapper.Map<PlayerBase>(x);
        }

        public GameBase GameStats(int id)
        {
            var x = ds.Games.Include("GameDatas").SingleOrDefault(t => t.Id == id);
           
            return (x == null) ? null : mapper.Map<GameBase>(x);
        }
    
        public GameBase GameById(int id)
        {
            var x = ds.Games.Include("ScreenShots").SingleOrDefault(t => t.Id == id);
            return (x == null) ? null : mapper.Map<GameBase>(x);
        }

    

        public GameDataBase DataGetById(int id)
        {
            // Attempt to fetch the object
            var o = ds.GameDatas.Include("Game").SingleOrDefault(t=>t.Id ==id);
            // Return the result, or null if not found
            return (o == null) ? null : mapper.Map<GameDataBase>(o);
        }

        public GameDataBase DataGetByPlayerId(int id)
        {
            // Attempt to fetch the object
            var o = ds.GameDatas.Include("Game").Include("Player").FirstOrDefault(t => t.Id == id);

            // Return the result, or null if not found
            return (o == null) ? null : mapper.Map<GameDataBase>(o);
        }

        public IEnumerable<GameDataBase> DataTest(string name)
        {

            var o = ds.GameDatas.Include("Game").Include("Player").Where(t => t.PlayerName== name);
          
            return mapper.Map<IEnumerable<GameDataBase>>(o);

        }
     


        public GameDataBase DataEdit(GameDataBase newItem)
        {
            var o = ds.GameDatas.Include("Game").SingleOrDefault(v => v.Id == newItem.Id);

            ds.Entry(o).CurrentValues.SetValues(newItem);
            o.PlayerName = newItem.PlayerName;
            ds.SaveChanges();

            return mapper.Map<GameDataBase>(o);
            }
        public PlayerBase PlayerEdit(PlayerBase newItem)
        {
            var o = ds.Players.Include("Game").SingleOrDefault(v => v.Id == newItem.Id);

            ds.Entry(o).CurrentValues.SetValues(newItem);
           // o.PlayerName = newItem.PlayerName;
            ds.SaveChanges();

            return mapper.Map<PlayerBase>(o);
        }


        public bool LoadData()
        {
            Game namegame = ds.Games.FirstOrDefault(t => t.Name == "LeagueOfLegends");
            ds.GameDatas.Add(new GameData { Data1 = 10,Data2 =40,Data3=50,Data4=30, Game= namegame});
        
            ds.SaveChanges();
            return true;
        }

        public GameDataBase DataAdd(GameDataBase newItem)
        {
           
            var a = ds.Games.Find(newItem.GameId);

            if (a == null)
            {
                return null;
            }
            else
            {
                var addedItem = ds.GameDatas.Add(mapper.Map<GameData>(newItem));
                addedItem.Game = a;
                ds.SaveChanges();

                return (addedItem == null) ? null : mapper.Map<GameDataBase>(addedItem);
            }
        }
        //delete all data for debugging / insertion
        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}