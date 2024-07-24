using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SibemWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "observacao",
                table: "bens");

            migrationBuilder.DropColumn(
                name: "inventariante",
                table: "Inventarios");

            migrationBuilder.RenameTable(
                name: "Igrejas",
                newName: "igrejas");

            migrationBuilder.RenameTable(
                name: "Inventarios",
                newName: "inventario");

            migrationBuilder.RenameColumn(
                name: "situacao",
                table: "bens",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "pdf",
                table: "inventario",
                newName: "inventariantes");

            migrationBuilder.AlterColumn<int>(
                name: "situacao",
                table: "igrejas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "lastInventario",
                table: "igrejas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "foto",
                table: "igrejas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "termino",
                table: "inventario",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "inicio",
                table: "inventario",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "inventario",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "bens",
                table: "inventario",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "igrejas",
                newName: "Igrejas");

            migrationBuilder.RenameTable(
                name: "inventario",
                newName: "Inventarios");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "bens",
                newName: "situacao");

            migrationBuilder.RenameColumn(
                name: "inventariantes",
                table: "Inventarios",
                newName: "pdf");

            migrationBuilder.AlterColumn<string>(
                name: "situacao",
                table: "Igrejas",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "lastInventario",
                table: "Igrejas",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "foto",
                table: "Igrejas",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "bens",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "termino",
                table: "Inventarios",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "inicio",
                table: "Inventarios",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "data",
                table: "Inventarios",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "bens",
                table: "Inventarios",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "inventariante",
                table: "Inventarios",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
