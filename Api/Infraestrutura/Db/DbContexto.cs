using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    public DbContexto(DbContextOptions<DbContexto> options) : base(options)
    {
    }

    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculo> Veiculos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Administradores com senha hash
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = GerarHashSenha("123456"),
                Perfil = "Adm"
            },
            new Administrador
            {
                Id = 2,
                Email = "joao@teste.com",
                Senha = GerarHashSenha("editor"),
                Perfil = "Editor"
            }
        );

        // Seed Veiculos
        modelBuilder.Entity<Veiculo>().HasData(
            new Veiculo { Id = 1, Nome = "Fiesta 2.0", Marca = "Ford", Ano = 2013 },
            new Veiculo { Id = 2, Nome = "X6", Marca = "BMW", Ano = 2022 }
        );
    }

    // Função para gerar hash SHA256 de uma senha
    private static string GerarHashSenha(string senha)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(senha);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToHexString(hash); // Retorna hash em hexadecimal
    }
}
