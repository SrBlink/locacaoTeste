using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locacao.Infrastructure.DataAccess.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Cnh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NumeroResidencia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelo_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ModeloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "date", nullable: true),
                    DataPrevistaDevolucao = table.Column<DateTime>(type: "date", nullable: true),
                    DataDevolucao = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fabricante",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("61d4e90e-6d25-4f7f-864c-431d95fbec68"), "FIAT" },
                    { new Guid("10f71d32-9501-4ba1-adbc-80627f206184"), "VW" },
                    { new Guid("6d0d79ba-e365-4a8a-839d-5e7860f5fce9"), "FORD" },
                    { new Guid("d764e865-1320-4f1f-8e45-89b85e799f75"), "AUDI" },
                    { new Guid("41f0ca61-e30a-44c0-9528-54c8c2da9c97"), "MERCEDES" },
                    { new Guid("3cf2a334-7be3-4aca-bb38-d3b5be815e95"), "JEEP" }
                });

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "Id", "FabricanteId", "Nome" },
                values: new object[,]
                {
                    { new Guid("36ac0748-e216-4aff-b36f-183cbea080da"), new Guid("61d4e90e-6d25-4f7f-864c-431d95fbec68"), "UNO" },
                    { new Guid("0467ffd8-0c81-46ca-87a9-e053babbd422"), new Guid("10f71d32-9501-4ba1-adbc-80627f206184"), "AMAROK" },
                    { new Guid("737b2921-ae1a-4529-acd1-cf0c8ceec90d"), new Guid("6d0d79ba-e365-4a8a-839d-5e7860f5fce9"), "AEROSTAR" },
                    { new Guid("536dc589-0ac2-475d-9d2f-6eee0bf1c7f6"), new Guid("d764e865-1320-4f1f-8e45-89b85e799f75"), "R8 GT SPYDER" },
                    { new Guid("9d15d8c6-d366-4b07-ba50-33f095546ffe"), new Guid("41f0ca61-e30a-44c0-9528-54c8c2da9c97"), "CITAN" },
                    { new Guid("ed0c08d8-13bd-4105-acbb-137dfc8a99e5"), new Guid("3cf2a334-7be3-4aca-bb38-d3b5be815e95"), "CHEROKEE" }
                });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "ModeloId", "Placa" },
                values: new object[] { new Guid("737b2921-ae1a-4529-acd1-cf0c8ceec90d"), new Guid("737b2921-ae1a-4529-acd1-cf0c8ceec90d"), "EQU2520" });

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_FabricanteId",
                table: "Modelo",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_VeiculoId",
                table: "Reserva",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ModeloId",
                table: "Veiculo",
                column: "ModeloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Fabricante");
        }
    }
}
