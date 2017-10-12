using PosRi.DataAccess.Model;
using PosRi.DataAccess.Seeder;
using PosRi.DataAccess.Utils;

namespace PosRi.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.PosRiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.PosRiContext context)
        {
            context.Roles.SeedEnumValues<Role, RoleNames>(@enum =>@enum);
            MexicanStatesSeeder.Seed(context);

            context.SaveChanges();
        }
    }
}
