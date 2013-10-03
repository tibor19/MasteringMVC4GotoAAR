using System.Data.Entity;
using TempHire.DomainModel;

namespace TempHire.MVC.Models.TempHire
{
    public class MVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TempHire.MVC.Models.TempHire.MVCContext>());

        public MVCContext() : base("name=MVCContext")
        {
        }

        public DbSet<AddressType> AddressTypes { get; set; }
    }
}
