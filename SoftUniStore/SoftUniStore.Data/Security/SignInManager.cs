using System.Linq;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SoftUniStore.Data.Contracts;
using SoftUniStore.Models;

namespace SoftUniStore.Data.Security
{
    public class SignInManager
    {
        private ISoftUniStoreData data;

        public SignInManager(ISoftUniStoreData data)
        {
            this.data = data;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.data.Logins.GetAll().Any(l => l.SessionId == session.Id && l.IsActive);
        }

        public User GetAuthenticatedUser(HttpSession session)
        {
            return this.data.Logins.GetAll().FirstOrDefault(l => l.SessionId == session.Id && l.IsActive).User;
        }

        public  void Logout(HttpSession session, HttpResponse response)
        {
            data.Logins.GetAll().FirstOrDefault(s => s.SessionId == session.Id).IsActive = false;
            data.SaveChanges();

            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
