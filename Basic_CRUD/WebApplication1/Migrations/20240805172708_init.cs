using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonRole = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Professor")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gpa = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonRole = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Student")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Email", "Name", "PersonRole", "Phone", "Salary" },
                values: new object[,]
                {
                    { 1, "professor1@example.com", "Professor1", "Professor", "0987654321", 5000f },
                    { 2, "professor2@example.com", "Professor2", "Professor", "0987654321", 5000f },
                    { 3, "professor3@example.com", "Professor3", "Professor", "0987654321", 5000f },
                    { 4, "professor4@example.com", "Professor4", "Professor", "0987654321", 5000f },
                    { 5, "professor5@example.com", "Professor5", "Professor", "0987654321", 5000f }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Gpa", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "student1@example.com", 3.5f, "Student1", "0123456789" },
                    { 2, "student2@example.com", 3.5f, "Student1", "0223456789" },
                    { 3, "student3@example.com", 3.5f, "Student1", "0323456789" },
                    { 4, "student4@example.com", 3.5f, "Student1", "0423456789" },
                    { 5, "student5@example.com", 3.5f, "Student1", "0523456789" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
