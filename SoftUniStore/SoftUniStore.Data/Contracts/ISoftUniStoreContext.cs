using System.Data.Entity;
using SoftUniStore.Models;

namespace SoftUniStore.Data.Contracts
{
    public interface ISoftUniStoreContext
    {    
        IDbSet<User> Users { get; }

        IDbSet<Login> Logins { get; }
        IDbSet<Game> Games { get; }
        DbContext DbContext { get; }

        int SaveChanges();

        IDbSet<T> Set<T>()
           where T : class;
    }
}
