using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practicaV1.Migrations
{
    /// <inheritdoc />
    public partial class practicaV1ContextHotelYCAContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tAlquiler",
                columns: table => new
                {
                    idAlquiler = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaHoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fkHabitacion = table.Column<int>(type: "int", nullable: false),
                    fkCliente = table.Column<int>(type: "int", nullable: false),
                    fkRegistrador = table.Column<int>(type: "int", nullable: false),
                    fkEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAlquiler", x => x.idAlquiler);
                });

            migrationBuilder.CreateTable(
                name: "tCliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fkNacionalidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCliente", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "tEstado",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tEstado", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "tHabitacion",
                columns: table => new
                {
                    idHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fkTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tHabitacion", x => x.idHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "tNacionalidad",
                columns: table => new
                {
                    idNacionalidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNacionalidad", x => x.idNacionalidad);
                });

            migrationBuilder.CreateTable(
                name: "tRegistrador",
                columns: table => new
                {
                    idRegistrador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tRegistrador", x => x.idRegistrador);
                });

            migrationBuilder.CreateTable(
                name: "tTipoHabitacion",
                columns: table => new
                {
                    idTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTipoHabitacion", x => x.idTipo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tAlquiler");

            migrationBuilder.DropTable(
                name: "tCliente");

            migrationBuilder.DropTable(
                name: "tEstado");

            migrationBuilder.DropTable(
                name: "tHabitacion");

            migrationBuilder.DropTable(
                name: "tNacionalidad");

            migrationBuilder.DropTable(
                name: "tRegistrador");

            migrationBuilder.DropTable(
                name: "tTipoHabitacion");
        }
    }
}
