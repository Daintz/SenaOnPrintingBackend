using System.Reflection;
using DataCape.Items;
using Microsoft.EntityFrameworkCore;

namespace PersistenceCape.Contexts
{
    public partial class SENAContext : DbContext
    {
        public SENAContext()
        {
        }

        public SENAContext(DbContextOptions<SENAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserItem> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
