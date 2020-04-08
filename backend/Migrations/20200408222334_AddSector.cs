using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddSector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "sectors",
                columns: new[] { "Id", "color", "description", "num_bed", "title" },
                values: new object[,]
                {
                    { 2, "rgba(255, 0, 0)", "Urgencia / Alta Complejidad", 5, "Sector C2" },
                    { 3, "rgb(255, 102, 0)", "Condicion de Mediana Complejidad", 5, "Sector C3" },
                    { 4, "rgb(255, 153, 0)", "No Urgente / Baja complejidad", 5, "Sector C4" },
                    { 5, null, "No Urgente / Atencion General", 5, "Sector C5" },
                    { 6, "#0f69b4", "Paciente en espera", 0, "Categorización" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sectors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "sectors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "sectors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "sectors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "sectors",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
