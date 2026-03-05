using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerAppTest.Migrations
{
    /// <inheritdoc />
    public partial class first22285 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasSubmitted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasSubmitted",
                table: "Students");
        }
    }
}
