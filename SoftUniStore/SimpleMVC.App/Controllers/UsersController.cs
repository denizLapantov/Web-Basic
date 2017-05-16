using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SoftUniStore.Data;
using SoftUniStore.Data.Contracts;
using SoftUniStore.Data.Security;
using SoftUniStore.Models;
using SoftUniStore.Models.BindingModels;
using SoftUniStore.Service;

namespace SimpleMVC.App.Controllers
{
    public class UsersController : Controller
    {

        private SignInManager manager;
        private UsersService service;

        public UsersController()
            :this(new SoftUniStoreData())
        {

        }

        public UsersController(ISoftUniStoreData data)
        {
            this.service = new UsersService(data);
            this.manager = new SignInManager(data);
        }
        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpSession session, HttpResponse response, RegisterUserbBm moBm)
        {
            if (!service.IsValidRegistrationViewModel(moBm))
            {
                Redirect(response, "/users/register");
                return null;
            }

            User user = this.service.GetUserByBm(moBm);
            this.service.RegisterUser(user);
            Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/index");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBm loginUserBm)
        {
            if (!this.service.IsLoginValid(loginUserBm))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User user = service.GetUserByLoginBm(loginUserBm);
            this.service.LoginUser(user, session);
            Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            this.manager.Logout(session, response);
            Redirect(response, "/users/login");
            return null;
        }
    }
}
