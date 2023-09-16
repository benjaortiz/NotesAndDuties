using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndDutiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class authorRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "duties",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
            name: "FK_User",
            table: "duties",
            column: "Author",
            principalTable: "users",
            principalColumn: "Username",
            onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "author",
                table: "duties");
        }
    }
}
