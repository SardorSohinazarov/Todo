using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todo.Infrastructure.Data.Configurations;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
            Database.Migrate();
        }

        public DbSet<Task> Tasks { get; set; }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken = default)
            => await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }
    }
}
