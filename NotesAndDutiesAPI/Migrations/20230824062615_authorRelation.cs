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
                name: "author",
                table: "duties",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
            name: "FK_Duties_Users",
            table: "duties",
            column: "author",
            principalTable: "users",
            principalColumn: "Username",
            onDelete: ReferentialAction.SetNull);
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
