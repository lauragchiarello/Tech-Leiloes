using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechLeiloes.API.Models;

namespace TechLeiloes.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Favoritos> Favoritos { get; set; }
    public DbSet<Foto> Fotos { get; set; }
    public DbSet<HistoricoLeilao> HistoricoLeiloes { get; set; }
    public DbSet<Leilao> Leiloes { get; set; }
    public DbSet<Leiloeiro> Leiloeiros { get; set; }
    public DbSet<SincronizacaoLeilao> SincronizacaoLeiloes { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Usuário",
               NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = new() {
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "gallojunior@gmail.com",
                NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
                UserName = "GalloJunior",
                NormalizedUserName = "GALLOJUNIOR",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Name = "José Antonio Gallo Junior"
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            new Categoria { Id = 1, Tipo = "Casa"},
            new Categoria { Id = 2, Tipo = "Apartamento"},
            new Categoria { Id = 3, Tipo = "Terreno"},
            new Categoria { Id = 4, Tipo = "Agência"},
            new Categoria { Id = 5, Tipo = "Galpão"},
            new Categoria { Id = 6, Tipo = "Comercial"},
            new Categoria { Id = 7, Tipo = "Área Rural"},
            new Categoria { Id = 8, Tipo = "Garagem"},
            new Categoria { Id = 9, Tipo = "Área Industrial"},
            new Categoria { Id = 10, Tipo = "Outros"}
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Estado> Estados = new()
        {
            new Estado { Id = 1, SiglaEstado = "AC"},
            new Estado { Id = 2, SiglaEstado = "AL"},
            new Estado { Id = 3, SiglaEstado = "AM"},
            new Estado { Id = 4, SiglaEstado = "AP"},
            new Estado { Id = 5, SiglaEstado = "BA"},
            new Estado { Id = 6, SiglaEstado = "CE"},
            new Estado { Id = 7, SiglaEstado = "DF"},
            new Estado { Id = 8, SiglaEstado = "ES"},
            new Estado { Id = 9, SiglaEstado = "GO"},
            new Estado { Id = 10, SiglaEstado = "MA"},
            new Estado { Id = 11, SiglaEstado = "MG"},
            new Estado { Id = 12, SiglaEstado = "MS"},
            new Estado { Id = 13, SiglaEstado = "MT"},
            new Estado { Id = 14, SiglaEstado = "PA"},
            new Estado { Id = 15, SiglaEstado = "PB"},
            new Estado { Id = 16, SiglaEstado = "PE"},
            new Estado { Id = 17, SiglaEstado = "PI"},
            new Estado { Id = 18, SiglaEstado = "PR"},
            new Estado { Id = 19, SiglaEstado = "RJ"},
            new Estado { Id = 20, SiglaEstado = "RN"},
            new Estado { Id = 21, SiglaEstado = "RO"},
            new Estado { Id = 22, SiglaEstado = "RR"},
            new Estado { Id = 23, SiglaEstado = "RS"},
            new Estado { Id = 24, SiglaEstado = "SC"},
            new Estado { Id = 25, SiglaEstado = "SE"},
            new Estado { Id = 26, SiglaEstado = "SP"},
            new Estado { Id = 27, SiglaEstado = "TO"}

        };
        builder.Entity<Estado>().HasData(Estados);
    }

}
