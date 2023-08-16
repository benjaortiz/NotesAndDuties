using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesAndDutiesAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "duties",
                columns: table => new
                {
                    DutyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duties", x => x.DutyId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });
            
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] {"UserId", "Username", "Password", "EmailAddress", "Role"},
                values: new object[] {"1", "admin1", "admin", "dutiesuser@admin.com", "admin"}
            );

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] {"UserId", "Username", "Password", "EmailAddress", "Role"},
                values: new object[] {"2", "Chazz", "TheChazz", "ChazzItUp@user.com", "user"}
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "duties");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
