using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mininal_api.Migrations
{
    public partial class AdministradorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySql.EntityFrameworkCore.Metadata.MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Perfil = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            // Seed de Administradores com hash de senha
            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "Email", "Senha", "Perfil" },
                values: new object[,]
                {
                    { 1, "administrador@teste.com", GerarHashSenha("123456"), "Adm" },
                    { 2, "joao@teste.com", GerarHashSenha("editor"), "Editor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");
        }

        // Função para gerar hash SHA256
        private static string GerarHashSenha(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hash); // retorna 64 caracteres hex
        }
    }
}
