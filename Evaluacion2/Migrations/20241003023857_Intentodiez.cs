using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evaluacion2.Migrations
{
    public partial class Intentodiez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Tareas");

            migrationBuilder.RenameColumn(
                name: "Responsable",
                table: "Tareas",
                newName: "ProyectoId");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Tareas",
                newName: "SetHerramientas");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Horas",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "Horas",
                table: "Tareas");

            migrationBuilder.RenameColumn(
                name: "SetHerramientas",
                table: "Tareas",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "ProyectoId",
                table: "Tareas",
                newName: "Responsable");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Tareas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
