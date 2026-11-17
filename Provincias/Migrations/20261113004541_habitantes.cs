using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Provincias.Migrations
{
    /// <inheritdoc />
    public partial class habitantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cantones",
                type: "longtext",
                nullable: false,
               
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Habitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido = table.Column<string>(type: "longtext", nullable: false),
                    Fecha_Nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    CantonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitantes_Cantones_CantonId",
                        column: x => x.CantonId,
                        principalTable: "Cantones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Habitantes_CantonId",
                table: "Habitantes",
                column: "CantonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitantes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cantones",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
