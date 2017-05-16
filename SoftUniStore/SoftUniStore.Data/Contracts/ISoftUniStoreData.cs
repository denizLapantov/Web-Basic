using SoftUniStore.Data.Repositories;
using SoftUniStore.Models;

namespace SoftUniStore.Data.Contracts
{
    public interface ISoftUniStoreData
    {


        Repository<User> Users { get; }

        Repository<Login> Logins { get; }

        Repository<Game> Games { get; }

        ISoftUniStoreContext Context { get; }

        int SaveChanges();
    }
}
