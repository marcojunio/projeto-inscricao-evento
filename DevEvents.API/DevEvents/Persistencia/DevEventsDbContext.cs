﻿using DevEvents.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.Persistencia
{
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {

        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Categoria)
                .WithMany()
                .HasForeignKey(e => e.IdCategoria);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Evento>()
                .Property(x => x.Descricao)
                .HasMaxLength(150);

            modelBuilder.Entity<Usuario>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Categoria>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Inscricao>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Evento)
                .WithMany(e => e.Inscricoes)
                .HasForeignKey(e => e.IdEvento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Usuario)
                .WithMany(e => e.Inscricoes)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
