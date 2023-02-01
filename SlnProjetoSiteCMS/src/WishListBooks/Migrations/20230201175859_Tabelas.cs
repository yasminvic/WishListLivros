using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WishListBooks.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoriaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "configuracaoSistema",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracaoSistema", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "livro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anolancamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro", x => x.id);
                    table.ForeignKey(
                        name: "FK_livro_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "livrosLidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    dataIni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    critica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avaliacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livrosLidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_livrosLidos_livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "livro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_livrosLidos_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "categoriaNome" },
                values: new object[,]
                {
                    { 1, "Suspense" },
                    { 2, "Fantasia" },
                    { 3, "Romance" },
                    { 4, "Autoajuda" },
                    { 5, "Religião" },
                    { 6, "Astronomia" }
                });

            migrationBuilder.InsertData(
                table: "configuracaoSistema",
                columns: new[] { "id", "contato", "endereco", "nomeSite" },
                values: new object[] { 1, "3333-3333", "wishlistbooks@gmail.com", "Wish List Books" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "createdDate", "email", "login", "nome", "perfil", "senha" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 1, 14, 58, 59, 306, DateTimeKind.Local).AddTicks(7088), "ana@gmail.com", "ana", "Ana de Souza", 1, "123" },
                    { 2, new DateTime(2023, 2, 1, 14, 58, 59, 306, DateTimeKind.Local).AddTicks(7124), "maria@gmail.com", "maria", "Maria Clara da Silva", 1, "123" },
                    { 3, new DateTime(2023, 2, 1, 14, 58, 59, 306, DateTimeKind.Local).AddTicks(7126), "laura@gmail.com", "laura", "Laura Muller", 2, "123" },
                    { 4, new DateTime(2023, 2, 1, 14, 58, 59, 306, DateTimeKind.Local).AddTicks(7127), "joao@gmail.com", "joao", "João Victor Machado", 1, "123" },
                    { 5, new DateTime(2023, 2, 1, 14, 58, 59, 306, DateTimeKind.Local).AddTicks(7128), "pietro@gmail.com", "pietro", "Pietro da Cruz", 2, "123" },
                    { 6, new DateTime(2023, 2, 1, 14, 58, 59, 306, DateTimeKind.Local).AddTicks(7129), "izabella@gmail.com", "izabella", "Izabella Luiza de Souza", 2, "123" },
                    { 7, new DateTime(2023, 2, 1, 14, 58, 59, 306, DateTimeKind.Local).AddTicks(7131), "antonia@gmail.com", "antonia", "Antonia Barborsa", 2, "123" }
                });

            migrationBuilder.InsertData(
                table: "livro",
                columns: new[] { "id", "anolancamento", "autor", "CategoriaId", "editora", "titulo" },
                values: new object[,]
                {
                    { 1, "2012", "Kiera Cass", 3, "Seguinte", "A Seleção" },
                    { 3, "2012", "Raphael Montes", 1, "Companhia das Letras", "Suicidas" },
                    { 4, "2004", "Neil deGrasse Tyson", 6, "Planeta", "Origens" },
                    { 5, "2016", "Raphael Montes", 1, "Companhia das Letras", "Jantar Secreto" },
                    { 6, "2014", "E. Lockhart", 1, "Seguinte", "Mentirosos" },
                    { 7, "2014", "Kiera Cass", 3, "Seguinte", "A Escolha" },
                    { 8, "2013", "Kiera Cass", 3, "Seguinte", "A Elite" },
                    { 9, "2015", "Kiera Cass", 3, "Seguinte", "A Herdeira" },
                    { 10, "2016", "Kiera Cass", 3, "Seguinte", "A Coroa" },
                    { 11, "2015", "Victoria Aveyard", 2, "Seguinte", "A Rainha Vermelha" },
                    { 12, "2016", "Victoria Aveyard", 2, "Seguinte", "Espada de Vidro" },
                    { 13, "2017", "Victoria Aveyard", 2, "Seguinte", "A Prisão do Rei" },
                    { 14, "2018", "Victoria Aveyard", 2, "Seguinte", "Tempestada de Guerra" },
                    { 15, "2019", "Victoria Aveyard", 2, "Seguinte", "Trono Destruído" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_livro_CategoriaId",
                table: "livro",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_livrosLidos_LivroId",
                table: "livrosLidos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_livrosLidos_UserId",
                table: "livrosLidos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracaoSistema");

            migrationBuilder.DropTable(
                name: "livrosLidos");

            migrationBuilder.DropTable(
                name: "livro");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
