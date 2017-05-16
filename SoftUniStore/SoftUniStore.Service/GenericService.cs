using System;
using System.Collections.Generic;
using SoftUniStore.Data.Contracts;
using SoftUniStore.Models;
using SoftUniStore.Models.BindingModels;
using SoftUniStore.Models.ViewModels;

namespace SoftUniStore.Service
{
    public class GenericService : BaseService
    {
        public GenericService(ISoftUniStoreData data) : base(data)
        {
        }


        public GenericVm GenericPage()
        {
            GenericVm model = new GenericVm();
            GenericAdminVm admin = new GenericAdminVm();
            var game = this.data.Games.GetAll();

            var list = new List<GenericAdminVm>();
            foreach (var onegame in game)
            {
                admin = new GenericAdminVm()
                {
                    Name = onegame.Title,
                    Price = onegame.Price,
                    Size = onegame.Size
                };
                list.Add(admin);
            }
            model.Generic = list ;

            return model;
        }

        public bool IsValidRegistrationViewModel(AddNewGameBm newGame)
        {

            if (Convert.ToBoolean((char.ToUpper(newGame.Title[0]) + newGame.Title.Substring(1))))
            {
                return false;
            }
            if (newGame.Price < 0)
            {
                return false;
            }
            if (newGame.Size.Contains("-"))
            {
                return false;

            }
            if (newGame.YouTubeId.Length != 11)
            {
                return false;
            }
            if (!newGame.ImageUrl.StartsWith("http://"))
            {
                return false;
            }
            if (newGame.Description.Length < 20)
            {
                return false;
            }

            return true;
        }


        public string UppercaseFirst(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public void AddNewGame(AddNewGameBm newGame)
        {
            Game game = new Game()
            {
                Description = newGame.Description,
                Title = newGame.Title,
                ReleaseDate = newGame.ReleaseDate,
                ImageUrl = newGame.ImageUrl,
                Price = newGame.Price,
                YouTubeId = newGame.YouTubeId,
                Size = newGame.Size
            };
            this.data.Games.InsertOrUpdate(game);
            this.data.Context.SaveChanges();

        }

        public void DeleteGame(int id)
        {
            Game game = this.data.Games.FindByPredicate(x => x.Id == id);
            this.data.Games.Delete(game);
            this.data.SaveChanges();
        }

        public AllEditVm EditGame(EditNewGameBm editNewGameBm)
        {

            AllEditVm vmodel = new AllEditVm();  
               var vm = new EditGameVm();
            var game = this.data.Games.GetAll();

            var list = new List<EditGameVm>();
            foreach (var oneGame in game)
            {
                vm = new EditGameVm();
                {
                oneGame.Title = editNewGameBm.OldTitle;
                oneGame.Price = editNewGameBm.OldPrice;
                oneGame.Description = editNewGameBm.OldDescription;
                oneGame.ImageUrl = editNewGameBm.OldImageUrl;
                oneGame.YouTubeId = editNewGameBm.OldYouTubeId;
                oneGame.ReleaseDate = editNewGameBm.OldReleaseDate;
                oneGame.Title = editNewGameBm.OldTitle;
            };
                this.data.SaveChanges();
                list.Add(vm);
            }
            vmodel.EditGameVms = list;

            return vmodel;

        
        }
    }
}
