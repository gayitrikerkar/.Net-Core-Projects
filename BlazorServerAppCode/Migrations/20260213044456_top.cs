using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerAppCode.Migrations
{
    /// <inheritdoc />
    public partial class top : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Teacher");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Teacher",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
