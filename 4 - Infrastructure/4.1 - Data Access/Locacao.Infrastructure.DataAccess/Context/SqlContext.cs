using Locacao.Domain.Entities;
using Locacao.Infrastructure.DataAccess.EntityMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locacao.Infrastructure.DataAccess.Context
{
    public class SqlContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SqlContext(DbContextOptions<SqlContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var connectionString = Environment.GetEnvironmentVariable("LOCACAO_SERVER");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(connectionString);
            Console.WriteLine("-----------------------------------------");

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = _configuration["ConnectionStrings:locacaoserver"];
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine(connectionString);
                Console.WriteLine("-----------------------------------------");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }

        #region DbSet

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new FabricanteMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    // comando para adicionar quando for adicionar alguma entidade
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    // comando para adicionar quando for adicionar alguma entidade
                }
            }
            return base.SaveChanges();
        }
    }
}