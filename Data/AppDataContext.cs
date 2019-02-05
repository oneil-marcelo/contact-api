using contact_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Api.Data
{
    public class AppDataContext : DbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactType> ContactTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer(@"Server=<myServidor>;Database=<namemydatabase>;User ID=SA; Password=<mypassword>;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactTypeMap());
            builder.ApplyConfiguration(new ContactMap());
        }
    }
}