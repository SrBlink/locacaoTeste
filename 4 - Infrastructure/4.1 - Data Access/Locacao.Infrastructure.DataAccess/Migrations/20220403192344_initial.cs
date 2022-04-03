using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locacao.Infrastructure.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("5827782d-924c-4307-a4df-13756af8a9e2"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("a6c53c0e-2c6e-4ad6-b594-003d67fc7dce"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("aeb99c70-bf83-4c0e-a8e4-7a414ad173d9"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("c86909e7-0514-44d6-a8d4-c7414fcfb1c3"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("ce760ddb-22de-4cdc-b840-216d6c657a1f"));

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculo",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "Id", "FabricanteId", "Nome" },
                values: new object[,]
                {
                    { new Guid("cc93a8db-8c3e-4da1-96e5-41bf8cd976b0"), new Guid("61d4e90e-6d25-4f7f-864c-431d95fbec68"), "UNO" },
                    { new Guid("0d5e3bf8-437f-4084-acef-d9f0e4baf482"), new Guid("10f71d32-9501-4ba1-adbc-80627f206184"), "AMAROK" },
                    { new Guid("238832b6-54c2-462e-bcc2-eaa3b2089ff3"), new Guid("d764e865-1320-4f1f-8e45-89b85e799f75"), "R8 GT SPYDER" },
                    { new Guid("50ad70a2-a931-4726-b61e-4b61ead577b3"), new Guid("41f0ca61-e30a-44c0-9528-54c8c2da9c97"), "CITAN" },
                    { new Guid("fd54f525-4164-4e63-a28d-7c1ddb635c5b"), new Guid("3cf2a334-7be3-4aca-bb38-d3b5be815e95"), "CHEROKEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("0d5e3bf8-437f-4084-acef-d9f0e4baf482"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("238832b6-54c2-462e-bcc2-eaa3b2089ff3"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("50ad70a2-a931-4726-b61e-4b61ead577b3"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("cc93a8db-8c3e-4da1-96e5-41bf8cd976b0"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("fd54f525-4164-4e63-a28d-7c1ddb635c5b"));

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculo",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "Id", "FabricanteId", "Nome" },
                values: new object[,]
                {
                    { new Guid("aeb99c70-bf83-4c0e-a8e4-7a414ad173d9"), new Guid("61d4e90e-6d25-4f7f-864c-431d95fbec68"), "UNO" },
                    { new Guid("ce760ddb-22de-4cdc-b840-216d6c657a1f"), new Guid("10f71d32-9501-4ba1-adbc-80627f206184"), "AMAROK" },
                    { new Guid("a6c53c0e-2c6e-4ad6-b594-003d67fc7dce"), new Guid("d764e865-1320-4f1f-8e45-89b85e799f75"), "R8 GT SPYDER" },
                    { new Guid("5827782d-924c-4307-a4df-13756af8a9e2"), new Guid("41f0ca61-e30a-44c0-9528-54c8c2da9c97"), "CITAN" },
                    { new Guid("c86909e7-0514-44d6-a8d4-c7414fcfb1c3"), new Guid("3cf2a334-7be3-4aca-bb38-d3b5be815e95"), "CHEROKEE" }
                });
        }
    }
}
