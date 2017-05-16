using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Data;
using SoftUniStore.Data.Contracts;
using SoftUniStore.Data.Security;
using SoftUniStore.Models.ViewModels;
using SoftUniStore.Service;

namespace SimpleMVC.App.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager manager;
        private HomeService service;
     

        public HomeController()
            :this(new SoftUniStoreData())
        {
          
        }

        public HomeController(ISoftUniStoreData data)
        {
            this.service = new HomeService(data);
            this.manager = new SignInManager(data);
        }
        [HttpGet]
        public IActionResult<AllGamesVm> Index(HttpResponse response, HttpSession session)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            AllGamesVm model = this.service.HomePage();
            return this.View(model);
        }

        public IActionResult<DetailsVm> Details(HttpResponse response,HttpSession session, int id)
        {

            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/forum/login");
                return null;
            }

            DetailsVm details = this.service.GetDetails(id);

            return this.View(details);
        }
    }
}
