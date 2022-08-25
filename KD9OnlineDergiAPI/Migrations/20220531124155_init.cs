using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KD9OnlineDergiAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YayınEvleri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayınEvleri", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dergiler",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dergiAdı = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dergiTürleri = table.Column<int>(type: "int", nullable: false),
                    yayınAralığı = table.Column<int>(type: "int", nullable: false),
                    yayınEviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dergiler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dergiler_YayınEvleri_yayınEviId",
                        column: x => x.yayınEviId,
                        principalTable: "YayınEvleri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sayılar",
                columns: table => new
                {
                    DergiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sayı = table.Column<int>(type: "int", nullable: false),
                    YayınTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SayfaSayısı = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sayılar", x => new { x.DergiId, x.sayı });
                    table.ForeignKey(
                        name: "FK_Sayılar_Dergiler_DergiId",
                        column: x => x.DergiId,
                        principalTable: "Dergiler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dergiler_dergiAdı",
                table: "Dergiler",
                column: "dergiAdı",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dergiler_yayınEviId",
                table: "Dergiler",
                column: "yayınEviId");

            migrationBuilder.CreateIndex(
                name: "IX_YayınEvleri_Name",
                table: "YayınEvleri",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sayılar");

            migrationBuilder.DropTable(
                name: "Dergiler");

            migrationBuilder.DropTable(
                name: "YayınEvleri");
        }
    }
}
