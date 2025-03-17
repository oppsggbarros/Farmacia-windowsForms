using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;

namespace Farmacia.Back_End.ConexaoBanco
{
    public class Conexao : DbContext
    {
        // public Conexao(DbContextOptions options) : base(options)
        // {
        // }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Medicamentos> Medicamentos { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        
        public DbSet<Fornecedores> Fornecedores { get; set; }

        public DbSet<Estoques> Estoque { get; set; }

        public DbSet<Relatorios> Relatorios { get; set; }
        public DbSet<Fornecedores_Medicamentos> Fornecedores_Medicamentos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=crud;Username=postgres;Password=1234");
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().ToTable("usuarios");
            modelBuilder.Entity<Medicamentos>().ToTable("medicamentos");
            modelBuilder.Entity<Vendas>().ToTable("vendas");
            modelBuilder.Entity<Fornecedores>().ToTable("fornecedores");
            modelBuilder.Entity<Estoques>().ToTable("estoques");
            modelBuilder.Entity<Relatorios>().ToTable("relatorios");
            modelBuilder.Entity<Fornecedores_Medicamentos>().ToTable("fornecedores_medicamentos");
        }        
    }
}
