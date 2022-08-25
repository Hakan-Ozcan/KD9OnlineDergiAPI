using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KD9OnlineDergiAPI.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SayıYazar",
                columns: table => new
                {
                    YazarlarId = table.Column<int>(type: "int", nullable: false),
                    YazdığıSayılarDergiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YazdığıSayılarsayı = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SayıYazar", x => new { x.YazarlarId, x.YazdığıSayılarDergiId, x.YazdığıSayılarsayı });
                    table.ForeignKey(
                        name: "FK_SayıYazar_Sayılar_YazdığıSayılarDergiId_YazdığıSayılarsayı",
                        columns: x => new { x.YazdığıSayılarDergiId, x.YazdığıSayılarsayı },
                        principalTable: "Sayılar",
                        principalColumns: new[] { "DergiId", "sayı" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SayıYazar_Yazarlar_YazarlarId",
                        column: x => x.YazarlarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SayıYazar_YazdığıSayılarDergiId_YazdığıSayılarsayı",
                table: "SayıYazar",
                columns: new[] { "YazdığıSayılarDergiId", "YazdığıSayılarsayı" });

            migrationBuilder.CreateIndex(
                name: "IX_Yazarlar_Name",
                table: "Yazarlar",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SayıYazar");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
