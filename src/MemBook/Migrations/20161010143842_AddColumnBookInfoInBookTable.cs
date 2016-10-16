using Microsoft.EntityFrameworkCore.Migrations;

namespace MemBook.Migrations
{
    public partial class AddColumnBookInfoInBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Annotation",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Annotation",
                table: "Books",
                nullable: false);
        }
    }
}
