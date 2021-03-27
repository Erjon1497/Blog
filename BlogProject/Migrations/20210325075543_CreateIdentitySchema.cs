using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_Users_UserId",
            //    table: "Comments");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comments_Users_UserId",
            //    table: "Comments",
            //    column: "UserId",
            //    principalTable: "Users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_Users_UserId",
            //    table: "Comments");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comments_Users_UserId",
            //    table: "Comments",
            //    column: "UserId",
            //    principalTable: "Users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
