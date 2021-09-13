using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Trade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FromCoinId = table.Column<long>(type: "bigint", nullable: false),
                    ToCoinId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentOfProfit = table.Column<int>(type: "int", nullable: false),
                    FromCoinValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToCoinValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_Coins_FromCoinId",
                        column: x => x.FromCoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_Coins_ToCoinId",
                        column: x => x.ToCoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trade_FromCoinId",
                table: "Trade",
                column: "FromCoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ToCoinId",
                table: "Trade",
                column: "ToCoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_UserId",
                table: "Trade",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trade");
        }
    }
}
