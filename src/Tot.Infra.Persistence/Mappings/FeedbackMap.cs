using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tot.Core.Entity;

namespace Tot.Infra.Persistence.Mappings
{
    internal class FeedbackMap : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback", "dbo");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Description)
                .HasColumnName("description")
                .HasMaxLength(280)
                .IsRequired();


            builder.Property(u => u.Creation)
                .HasColumnName("creation")
                .IsRequired();

            builder.Property(u => u.GroupId)
                .HasColumnName("group_id")
                .IsRequired();

            builder.HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId);
        }
    }
}