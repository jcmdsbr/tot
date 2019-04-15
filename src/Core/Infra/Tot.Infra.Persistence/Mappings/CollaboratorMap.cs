using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tot.Shared.Models;

namespace Tot.Infra.Persistence.Mappings
{
    internal class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable("Collaborator", "dbo");
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