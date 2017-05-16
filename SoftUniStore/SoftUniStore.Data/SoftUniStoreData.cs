using SoftUniStore.Data.Contracts;
using SoftUniStore.Data.Repositories;
using SoftUniStore.Models;

namespace SoftUniStore.Data
{
    public class SoftUniStoreData : ISoftUniStoreData
    {
        private readonly ISoftUniStoreContext context;

        public SoftUniStoreData()
            :this(new SoftUniStoreContext())
        {

        }
        public SoftUniStoreData(ISoftUniStoreContext context)
        {
            this.context = context;
        }

        public Repository<User> Users => new Repository<User>(this.context);
        public Repository<Login> Logins =>new Repository<Login>(this.context);
        public Repository<Game> Games =>new Repository<Game>(this.context);
        public ISoftUniStoreContext Context => this.context;
        public int SaveChanges()
        {
            return this.Context.DbContext.SaveChanges();
        }
    }
}
