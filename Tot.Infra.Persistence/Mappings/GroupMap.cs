using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tot.Core.Entity;

namespace Tot.Infra.Persistence.Mappings
{
    internal class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group", "dbo");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Description)
                .HasColumnName("description")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}