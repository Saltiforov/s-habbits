using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace S_Habbits.Migrations
{
    public partial class FixDbContextAfterAddUsersAndHabbitsWithEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habbits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habbits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habbits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HabbitEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HabbitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabbitEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabbitEvents_Habbits_HabbitId",
                        column: x => x.HabbitId,
                        principalTable: "Habbits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabbitEvents_HabbitId",
                table: "HabbitEvents",
                column: "HabbitId");

            migrationBuilder.CreateIndex(
                name: "IX_Habbits_UserId",
                table: "Habbits",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabbitEvents");

            migrationBuilder.DropTable(
                name: "Habbits");
        }
    }
}
