using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Login_Page
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=2605;Database=AulaWindowsForm");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
        }
    }
        [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("cargo")]
        public string Cargo { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
        
        [Column("senha")]
        public string Senha { get; set; }
    }
}