using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddPatiens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "current_acount",
                table: "patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "current_acount", "destination", "diagnosis", "him", "more_12h", "sectorId", "start", "type_bed", "ugcc", "years" },
                values: new object[,]
                {
                    { 1, "132343413", "", "cod-19", "nose que es", false, 1, 0, null, "menos", 19 },
                    { 2, "98773672", "", "dolor de cabeza", "nose que es", false, 1, 0, null, "menos", 34 },
                    { 3, "32565476", "", "paro cardio respiratorio", "nose que es", false, 3, 0, null, "menos", 29 },
                    { 4, "43536453", "", "corazon roto :c", "nose que es", false, 6, 0, null, "menos", 33 },
                    { 5, "3432355", "", "se pego en el dedo chico del pie", "nose que es", false, 6, 0, null, "menos", 23 },
                    { 6, "4343532", "", "torcedura de tobillo", "nose que es", false, 6, 0, null, "menos", 73 },
                    { 7, "234-134-1341", "", "quemaduras de gravedad", "nose que es", false, 6, 0, null, "menos", 19 },
                    { 8, "213-123-2412", "", "fractura externa sector femur", "nose que es", false, 6, 0, null, "menos", 19 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "current_acount",
                table: "patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
