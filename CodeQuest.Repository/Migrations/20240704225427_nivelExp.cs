using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeQuest.Repository.Migrations
{
    /// <inheritdoc />
    public partial class nivelExp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "AspNetUsers");
        }
    }
}
