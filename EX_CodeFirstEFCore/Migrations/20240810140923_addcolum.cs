using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EX_CodeFirstEFCore.Migrations
{
    /// <inheritdoc />
    public partial class addcolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Std",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Std",
                table: "Students");
        }
    }
}
