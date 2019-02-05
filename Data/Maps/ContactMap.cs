using contact_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact_Api.Data
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
       
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(40)").HasMaxLength(40);
            builder.Property(x => x.Email).HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property(x => x.Phone).IsRequired().HasColumnType("varchar(9)").HasMaxLength(9);
            builder.Property(x => x.Street).IsRequired().HasColumnType("varchar(40)").HasMaxLength(40);
            builder.Property(x => x.Number).IsRequired().HasColumnType("int");
            builder.Property(x => x.District).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property(x => x.City).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property(x => x.State).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property(x => x.ZipCode).IsRequired().HasColumnType("varchar(8)").HasMaxLength(8);
            builder.HasOne(x => x.ContacType).WithMany(x => x.Contacts);

        }   
    }
}