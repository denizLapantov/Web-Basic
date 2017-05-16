using IssueTracker.Data.Contracts;
using IssueTracker.Models;

namespace IssueTracker.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class IssueTrackerContext : DbContext ,IIssueTrackerContext
    {
       
        public IssueTrackerContext()
            : base("name=IssueTrackerContext")
        {
        }

       
        public IDbSet<User> Users { get; set; }
        public IDbSet<Login> Logins { get; set; }
        public IDbSet<Issue> Issues { get; set; }
        public DbContext DbContext => this;
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }

  
}