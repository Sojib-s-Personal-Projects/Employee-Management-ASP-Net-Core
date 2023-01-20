using Infrastructure.Entities;
using Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
    ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly ServerVersion _serverVersion;

        public ApplicationDbContext(string connectionString,ServerVersion serverVersion, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _serverVersion = serverVersion;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString,_serverVersion,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasKey(w => w.Roll);

            modelBuilder.Entity<Worker>()
                .HasData(new WorkerSeed().Workers);

            modelBuilder.Entity<WorkerInfo>()
            .HasOne<Worker>(s => s.Worker)
            .WithOne(ad=>ad.WorkerInfo)
            .HasForeignKey<WorkerInfo>(ad => ad.Roll);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerInfo> WorkersInformation { get; set; }
    }
}