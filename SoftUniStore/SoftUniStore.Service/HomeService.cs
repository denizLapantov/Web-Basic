using System.Collections.Generic;
using System.Linq;
using SoftUniStore.Data.Contracts;
using SoftUniStore.Models;
using SoftUniStore.Models.ViewModels;

namespace SoftUniStore.Service
{
    public class HomeService : BaseService
    {
        public HomeService(ISoftUniStoreData data) : base(data)
        {
        }

        public AllGamesVm HomePage()
        {
          
          AllGamesVm model = new AllGamesVm();
          //  AllGamesViewModel all = new AllGamesViewModel();
        
                 IEnumerable<AllGamesViewModel> allGamesView = this.data.Games.GetAll().Select(x=> new AllGamesViewModel()
                {
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Size = x.Size,
                    Title = x.Title,
                });


                model.AllGamesViewModel = allGamesView;
          

            return model;
        }

        public DetailsVm GetDetails(int id)
        {
            DetailsVm model = new DetailsVm();

            Game game = this.data.Games.FindByPredicate(x => x.Id == id);

           var details = new List<DetailsGameVm>();

            DetailsGameVm newGameVm = new DetailsGameVm()
            {
                Description = game.Description,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                Size = game.Size,
                Title = game.Title,
                YouTubeId = game.YouTubeId
            };
            
            details.Add(newGameVm);
            model.DetailsGameVms = details;

            return model;
        }
    }
}
