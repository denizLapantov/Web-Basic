using System.Linq;
using SimpleHttpServer.Models;
using SoftUniStore.Data.Contracts;
using SoftUniStore.Models;
using SoftUniStore.Models.BindingModels;

namespace SoftUniStore.Service
{
    public class UsersService : BaseService
    {
        public UsersService(ISoftUniStoreData data) : base(data)
        {
        }


        public bool IsValidRegistrationViewModel(RegisterUserbBm moBm)
        {
            if (!moBm.Email.Contains("@") || !moBm.Email.Contains("."))
            {
                return false;
            }
            if (moBm.Password.Length < 6 
                || !moBm.Password.Any(char.IsUpper)
                || !moBm.Password.Any(char.IsDigit) 
                || !moBm.Password.Any(char.IsDigit))
            {
                return false;
            }
            if (string.IsNullOrEmpty(moBm.FullName))
            {
                return false;
            }
            if (moBm.Password != moBm.ConfirmPassword)
            {
                return false;
            }

            return true;
        }

        public User GetUserByBm(RegisterUserbBm moBm)
        {
            return new User()
            {
                Email = moBm.Email,
                Password = moBm.Password,
                FullName = moBm.FullName,                
            };
        }


        public void RegisterUser(User user)
        {
            if (!this.data.Users.GetAll().Any())
            {
                user.IsAdmin = true;
            }
            this.data.Users.InsertOrUpdate(user);
            this.data.SaveChanges();
        }

        public bool IsLoginValid(LoginUserBm loginUserBm)
        {
            if (this.data.Users.GetAll().Any(x => x.Email == loginUserBm.Email  && x.Password == loginUserBm.Password))
            {
                return true;
            }
            return false;
        }

        public User GetUserByLoginBm(LoginUserBm loginUserBm)
        {
            return
                  this.data.Users.GetAll()
                      .First(
                          x =>
                              x.Email == loginUserBm.Email 
                              && x.Password == loginUserBm.Password);
        }

        public void LoginUser(User user, HttpSession session)
        {
            this.data.Logins.InsertOrUpdate(new Login()
            {
                SessionId = session.Id,
                IsActive = true,
                User = user
            });
            this.data.SaveChanges();
        }
    }
}
