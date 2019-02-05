using contact_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact_Api.Data
{
    public class ContactTypeMap : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.ToTable("ContactType");
            builder.HasKey( x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
        }

    }
}