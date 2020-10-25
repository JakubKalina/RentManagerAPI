using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangedOneToOneIntoOneToManyInFlatClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms",
                column: "FlatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms",
                column: "FlatId",
                unique: true);
        }
    }
}
