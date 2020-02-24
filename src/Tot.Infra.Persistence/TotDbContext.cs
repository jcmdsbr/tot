using Microsoft.EntityFrameworkCore;
using Tot.Infra.Persistence.Mappings;
using Tot.Shared.Models;

namespace Tot.Infra.Persistence
{
    public class TotDbContext : DbContext
    {
        public TotDbContext(DbContextOptions<TotDbContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CollaboratorMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new FeedbackMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}