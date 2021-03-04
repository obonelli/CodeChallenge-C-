using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCodeFirst1.Migrations
{
    public partial class favoritos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "favoritos",
                table: "Blogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "favoritos",
                table: "Blogs");
        }
    }
}
