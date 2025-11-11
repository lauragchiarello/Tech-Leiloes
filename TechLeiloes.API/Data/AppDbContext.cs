
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechLeiloes.API.Models;


namespace TechLeiloes.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Leiloeiro> Leiloeiros { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Imovel> Imoveis { get; set; }
    public DbSet<Foto> Fotos { get; set; }
    public DbSet<Favorito> Favoritos { get; set; }
    public DbSet<HistoricoLeilao> HistoricosLeilao { get; set; }
    public DbSet<SincronizacaoSiteLeiloeiro> Sincronizacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedEstadoPadrao(builder);
        SeedStatusPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
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
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        
        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "gallojunior@gmail.com",
                NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
                UserName = "gallouunior@gmail.com",
                NormalizedUserName = "GALLOJUNIOR@GMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "José Antonio Gallo Junior",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Profissao = "Administrador do Sistema",
                Telefone = "11999999999"
                
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
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

    private static void SeedEstadoPadrao(ModelBuilder builder)
    {
        List<Estado> Estados = new()
        {
                new Estado { Id = 1, SiglaEstado = "AC", NomeEstado = "Acre" },
                new Estado { Id = 2, SiglaEstado = "AL", NomeEstado = "Alagoas" },
                new Estado { Id = 3, SiglaEstado = "AM", NomeEstado = "Amazonas" },
                new Estado { Id = 4, SiglaEstado = "AP", NomeEstado = "Amapá" },
                new Estado { Id = 5, SiglaEstado = "BA", NomeEstado = "Bahia" },
                new Estado { Id = 6, SiglaEstado = "CE", NomeEstado = "Ceará" },
                new Estado { Id = 7, SiglaEstado = "DF", NomeEstado = "Distrito Federal" },
                new Estado { Id = 8, SiglaEstado = "ES", NomeEstado = "Espírito Santo" },
                new Estado { Id = 9, SiglaEstado = "GO", NomeEstado = "Goiás" },
                new Estado { Id = 10, SiglaEstado = "MA", NomeEstado = "Maranhão" },
                new Estado { Id = 11, SiglaEstado = "MG", NomeEstado = "Minas Gerais" },
                new Estado { Id = 12, SiglaEstado = "MS", NomeEstado = "Mato Grosso do Sul" },
                new Estado { Id = 13, SiglaEstado = "MT", NomeEstado = "Mato Grosso" },
                new Estado { Id = 14, SiglaEstado = "PA", NomeEstado = "Pará" },
                new Estado { Id = 15, SiglaEstado = "PB", NomeEstado = "Paraíba" },
                new Estado { Id = 16, SiglaEstado = "PE", NomeEstado = "Pernambuco" },
                new Estado { Id = 17, SiglaEstado = "PI", NomeEstado = "Piauí" },
                new Estado { Id = 18, SiglaEstado = "PR", NomeEstado = "Paraná" },
                new Estado { Id = 19, SiglaEstado = "RJ", NomeEstado = "Rio de Janeiro" },
                new Estado { Id = 20, SiglaEstado = "RN", NomeEstado = "Rio Grande do Norte" },
                new Estado { Id = 21, SiglaEstado = "RO", NomeEstado = "Rondônia" },
                new Estado { Id = 22, SiglaEstado = "RR", NomeEstado = "Roraima" },
                new Estado { Id = 23, SiglaEstado = "RS", NomeEstado = "Rio Grande do Sul" },
                new Estado { Id = 24, SiglaEstado = "SC", NomeEstado = "Santa Catarina" },
                new Estado { Id = 25, SiglaEstado = "SE", NomeEstado = "Sergipe" },
                new Estado { Id = 26, SiglaEstado = "SP", NomeEstado = "São Paulo" },
                new Estado { Id = 27, SiglaEstado = "TO", NomeEstado = "Tocantins" }

        };
        builder.Entity<Estado>().HasData(Estados);
    }
    private static void SeedStatusPadrao(ModelBuilder builder)
    {
        builder.Entity<Status>().HasData(
            new Status { Id = 1, TipoStatus = TipoStatus.Ativo },
            new Status { Id = 2, TipoStatus = TipoStatus.Suspenso },
            new Status { Id = 3, TipoStatus = TipoStatus.Cancelado },
            new Status { Id = 4, TipoStatus = TipoStatus.Vendido }
        );
    }
}
