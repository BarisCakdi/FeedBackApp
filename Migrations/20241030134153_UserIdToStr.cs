using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackApp.Migrations
{
    /// <inheritdoc />
    public partial class UserIdToStr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_FeedBacks_FeedbackId",
                table: "Commits");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "Commits",
                newName: "FeedBackId");

            migrationBuilder.RenameIndex(
                name: "IX_Commits_FeedbackId",
                table: "Commits",
                newName: "IX_Commits_FeedBackId");

            migrationBuilder.AlterColumn<int>(
                name: "CommitId",
                table: "Commits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_FeedBacks_FeedBackId",
                table: "Commits",
                column: "FeedBackId",
                principalTable: "FeedBacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_FeedBacks_FeedBackId",
                table: "Commits");

            migrationBuilder.RenameColumn(
                name: "FeedBackId",
                table: "Commits",
                newName: "FeedbackId");

            migrationBuilder.RenameIndex(
                name: "IX_Commits_FeedBackId",
                table: "Commits",
                newName: "IX_Commits_FeedbackId");

            migrationBuilder.AlterColumn<int>(
                name: "CommitId",
                table: "Commits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_FeedBacks_FeedbackId",
                table: "Commits",
                column: "FeedbackId",
                principalTable: "FeedBacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
