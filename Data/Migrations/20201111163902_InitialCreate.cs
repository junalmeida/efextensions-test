using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainEntitites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    TestRound = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEntitites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    PropertyA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PropertyB = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PropertyC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MainEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryEntity_MainEntitites_MainEntityId",
                        column: x => x.MainEntityId,
                        principalTable: "MainEntitites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainEntitites_TestRound",
                table: "MainEntitites",
                column: "TestRound");

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryEntity_MainEntityId",
                table: "SecondaryEntity",
                column: "MainEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondaryEntity");

            migrationBuilder.DropTable(
                name: "MainEntitites");
        }
    }
}
