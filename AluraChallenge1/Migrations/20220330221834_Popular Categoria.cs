using Microsoft.EntityFrameworkCore.Migrations;

namespace AluraChallenge1.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Id, Titulo, Cor)" +
                "VALUES(1, 'Livre', 'Verde')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
