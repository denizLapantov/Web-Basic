using SoftUniStore.Data.Contracts;
using SoftUniStore.Models;

namespace SoftUniStore.Data
{
    using System.Data.Entity;

    public class SoftUniStoreContext : DbContext , ISoftUniStoreContext
    {
        
        public SoftUniStoreContext()
            : base("name=SoftUniStoreContext")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Login> Logins { get; set; }
        public IDbSet<Game> Games { get; set; }
        public DbContext DbContext => this;
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }

  
}