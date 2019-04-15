using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tot.Core.Entity;

namespace Tot.Infra.Persistence.Mappings
{
    internal class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", "dbo");

            builder.HasKey(u => new { u.CollaboratorId, u.GroupId });

            builder.Property(u => u.CollaboratorId)
                .HasColumnName("collaborator_id")
                .IsRequired();

            builder.Property(u => u.GroupId)
                .HasColumnName("group_id")
                .IsRequired();


            builder.HasOne(s => s.Collaborator)
                .WithMany(x => x.Roles)
                .HasForeignKey(e => e.CollaboratorId)
                .IsRequired();

            builder.HasOne(s => s.Group)
                .WithMany(x => x.Roles)
                .HasForeignKey(e => e.GroupId)
                .IsRequired();
        }
    }
}