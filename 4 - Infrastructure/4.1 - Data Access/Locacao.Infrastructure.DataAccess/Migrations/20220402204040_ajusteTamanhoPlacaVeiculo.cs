using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locacao.Infrastructure.DataAccess.Migrations
{
    public partial class ajusteTamanhoPlacaVeiculo : Migration
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
                    { new Guid("54aeb0ea-6412-47fd-b575-36916f4c06bb"), new Guid("61d4e90e-6d25-4f7f-864c-431d95fbec68"), "UNO" },
                    { new Guid("851a3734-1990-400b-abeb-9db42cc16cee"), new Guid("10f71d32-9501-4ba1-adbc-80627f206184"), "AMAROK" },
                    { new Guid("db8e5f46-a9f3-4c79-9fd7-13f205ce48ea"), new Guid("d764e865-1320-4f1f-8e45-89b85e799f75"), "R8 GT SPYDER" },
                    { new Guid("d71e1fb5-c808-44fd-9039-30ddd93ad75d"), new Guid("41f0ca61-e30a-44c0-9528-54c8c2da9c97"), "CITAN" },
                    { new Guid("d7f62d69-3de7-4c20-9ed7-38ae5a73f5b5"), new Guid("3cf2a334-7be3-4aca-bb38-d3b5be815e95"), "CHEROKEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("54aeb0ea-6412-47fd-b575-36916f4c06bb"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("851a3734-1990-400b-abeb-9db42cc16cee"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("d71e1fb5-c808-44fd-9039-30ddd93ad75d"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("d7f62d69-3de7-4c20-9ed7-38ae5a73f5b5"));

            migrationBuilder.DeleteData(
                table: "Modelo",
                keyColumn: "Id",
                keyValue: new Guid("db8e5f46-a9f3-4c79-9fd7-13f205ce48ea"));

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
