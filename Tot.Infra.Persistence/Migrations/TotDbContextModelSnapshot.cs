﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Tot.Infra.Persistence.Migrations
{
    [DbContext(typeof(TotDbContext))]
    internal class TotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tot.Core.Entity.Collaborator", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                b.HasKey("Id");

                b.ToTable("Collaborator", "dbo");
            });

            modelBuilder.Entity("Tot.Core.Entity.Feedback", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                b.Property<DateTime>("Creation")
                    .HasColumnName("creation");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(280);

                b.Property<int>("GroupId")
                    .HasColumnName("group_id");

                b.HasKey("Id");

                b.HasIndex("GroupId");

                b.ToTable("Feedback", "dbo");
            });

            modelBuilder.Entity("Tot.Core.Entity.Group", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                b.HasKey("Id");

                b.ToTable("Group", "dbo");
            });

            modelBuilder.Entity("Tot.Core.Entity.Role", b =>
            {
                b.Property<int>("CollaboratorId")
                    .HasColumnName("collaborator_id");

                b.Property<int>("GroupId")
                    .HasColumnName("group_id");

                b.HasKey("CollaboratorId", "GroupId");

                b.HasIndex("GroupId");

                b.ToTable("Role", "dbo");
            });

            modelBuilder.Entity("Tot.Core.Entity.Feedback", b =>
            {
                b.HasOne("Tot.Core.Entity.Group", "Group")
                    .WithMany()
                    .HasForeignKey("GroupId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Tot.Core.Entity.Role", b =>
            {
                b.HasOne("Tot.Core.Entity.Collaborator", "Collaborator")
                    .WithMany("Roles")
                    .HasForeignKey("CollaboratorId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Tot.Core.Entity.Group", "Group")
                    .WithMany("Roles")
                    .HasForeignKey("GroupId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}