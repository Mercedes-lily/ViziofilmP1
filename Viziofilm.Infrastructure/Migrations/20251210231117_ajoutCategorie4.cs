using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viziofilm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajoutCategorie4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nom",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "numero",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "limiteAppareils",
                table: "Abonnements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nom",
                table: "Abonnements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "numero",
                table: "Abonnements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "prixMensuel",
                table: "Abonnements",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nom",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "numero",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "limiteAppareils",
                table: "Abonnements");

            migrationBuilder.DropColumn(
                name: "nom",
                table: "Abonnements");

            migrationBuilder.DropColumn(
                name: "numero",
                table: "Abonnements");

            migrationBuilder.DropColumn(
                name: "prixMensuel",
                table: "Abonnements");
        }
    }
}
