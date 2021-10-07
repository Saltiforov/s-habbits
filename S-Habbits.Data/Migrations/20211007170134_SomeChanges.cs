using Microsoft.EntityFrameworkCore.Migrations;

namespace S_Habbits.Data.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "ToDoTasks",
                newName: "CreateDateTime");

            migrationBuilder.RenameColumn(
                name: "CheckedTime",
                table: "HabbitEvents",
                newName: "DateTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "HabbitEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "HabbitEvents");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "ToDoTasks",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "HabbitEvents",
                newName: "CheckedTime");
        }
    }
}
