using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeQuest.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "QuestaoTopicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoTopicos_UserId",
                table: "QuestaoTopicos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestaoTopicos_AspNetUsers_UserId",
                table: "QuestaoTopicos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestaoTopicos_AspNetUsers_UserId",
                table: "QuestaoTopicos");

            migrationBuilder.DropIndex(
                name: "IX_QuestaoTopicos_UserId",
                table: "QuestaoTopicos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuestaoTopicos");
        }
    }
}
