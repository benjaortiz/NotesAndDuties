using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndDutiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class notesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_users_Username",
                table: "users",
                column: "Username");

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_notes_users_Author",
                        column: x => x.Author,
                        principalTable: "users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_duties_Author",
                table: "duties",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_notes_Author",
                table: "notes",
                column: "Author");

            migrationBuilder.AddForeignKey(
                name: "FK_duties_users_Author",
                table: "duties",
                column: "Author",
                principalTable: "users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_duties_users_Author",
                table: "duties");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_users_Username",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_duties_Author",
                table: "duties");
        }
    }
}
