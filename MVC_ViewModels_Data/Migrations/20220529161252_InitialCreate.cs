using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_ViewModels_Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    City = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "City", "ContactNumber", "Name" },
                values: new object[] { 1, "Kurnool", "034-4242-657", "Priya" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "City", "ContactNumber", "Name" },
                values: new object[] { 2, "Kurnool", "034-4242-658", "Keerthi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
