using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.Data;
using SoftUniStore.Data.Contracts;
using SoftUniStore.Data.Security;
using SoftUniStore.Models;
using SoftUniStore.Models.BindingModels;
using SoftUniStore.Models.ViewModels;
using SoftUniStore.Service;

namespace SimpleMVC.App.Controllers
{
    public class GenericController : Controller
    {
        private SignInManager manager;
        private GenericService service;


        public GenericController()
            :this(new SoftUniStoreData())
        {

        }

        public GenericController(ISoftUniStoreData data)
        {
            this.service = new GenericService(data);
            this.manager = new SignInManager(data);
        }

        public IActionResult<GenericVm> All(HttpSession session,HttpResponse response)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User getUser = manager.GetAuthenticatedUser(session);
            if (!getUser.IsAdmin)
            {
                Redirect(response, "/home/index");
                return null;
            }

            GenericVm model = this.service.GenericPage();

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Add(HttpResponse response,HttpSession session)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User getUser = manager.GetAuthenticatedUser(session);
            if (!getUser.IsAdmin)
            {
                Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }


        [HttpPost]
        public IActionResult Add(HttpResponse response, HttpSession session,AddNewGameBm newGame)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User getUser = manager.GetAuthenticatedUser(session);
            if (!getUser.IsAdmin)
            {
                Redirect(response, "/home/index");
                return null;
            }

            //if (!service.IsValidRegistrationViewModel(newGame))
            //{
            //    Redirect(response, "/generic/add");
            //    return null;
            //}

            this.service.AddNewGame(newGame);
            Redirect(response,"home/index");
            return null;

        }
        [HttpGet]
        public IActionResult Delete(HttpResponse response, HttpSession session)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User getUser = manager.GetAuthenticatedUser(session);
            if (!getUser.IsAdmin)
            {
                Redirect(response, "/home/index");
                return null;
            }

           // this.service.DeleteGame(id);
            return this.View();
        }
        [HttpGet]
        public IActionResult Edit(HttpResponse response, HttpSession session)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User getUser = manager.GetAuthenticatedUser(session);
            if (!getUser.IsAdmin)
            {
                Redirect(response, "/home/index");
                return null;
            }
         
            return this.View();
        }

        [HttpPost]
        public IActionResult<AllEditVm> Edit(HttpResponse response, HttpSession session,EditNewGameBm editNewGameBm)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User getUser = manager.GetAuthenticatedUser(session);
            if (!getUser.IsAdmin)
            {
                Redirect(response, "/home/index");
                return null;
            }
            AllEditVm mode = this.service.EditGame(editNewGameBm);

            return this.View(mode);
        }

        [HttpGet]
        public IActionResult Delete(HttpResponse response, HttpSession session,int id)
        {
            if (!manager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            User getUser = manager.GetAuthenticatedUser(session);
            if (!getUser.IsAdmin)
            {
                Redirect(response, "/home/index");
                return null;
            }

           this.service.DeleteGame(id);
            return this.View();
        }
      

    }
}
