using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viziofilm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initwitheveryclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieFilm",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieFilm", x => new { x.CategoriesId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_CategorieFilm_Categorie_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieFilm_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguePiste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguePiste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomUsager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    motDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addresseCourriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aAccepteRecevoirNotification = table.Column<bool>(type: "bit", nullable: false),
                    languePreferee = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmLanguePiste",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    LanguePistesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmLanguePiste", x => new { x.FilmsId, x.LanguePistesId });
                    table.ForeignKey(
                        name: "FK_FilmLanguePiste_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmLanguePiste_LanguePiste_LanguePistesId",
                        column: x => x.LanguePistesId,
                        principalTable: "LanguePiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorieMembre",
                columns: table => new
                {
                    CategoriePrefereesId = table.Column<int>(type: "int", nullable: false),
                    MembresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieMembre", x => new { x.CategoriePrefereesId, x.MembresId });
                    table.ForeignKey(
                        name: "FK_CategorieMembre_Categorie_CategoriePrefereesId",
                        column: x => x.CategoriePrefereesId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieMembre_Membre_MembresId",
                        column: x => x.MembresId,
                        principalTable: "Membre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieFilm_FilmsId",
                table: "CategorieFilm",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMembre_MembresId",
                table: "CategorieMembre",
                column: "MembresId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmLanguePiste_LanguePistesId",
                table: "FilmLanguePiste",
                column: "LanguePistesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieFilm");

            migrationBuilder.DropTable(
                name: "CategorieMembre");

            migrationBuilder.DropTable(
                name: "FilmLanguePiste");

            migrationBuilder.DropTable(
                name: "Membre");

            migrationBuilder.DropTable(
                name: "LanguePiste");
        }
    }
}
