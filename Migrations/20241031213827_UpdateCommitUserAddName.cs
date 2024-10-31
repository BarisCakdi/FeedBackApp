using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommitUserAddName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Commits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Commits");
        }
    }
}
