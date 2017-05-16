namespace SoftUniStore.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftUniStore.Data.SoftUniStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SoftUniStore.Data.SoftUniStoreContext context)
        {
           
        }
    }
}
