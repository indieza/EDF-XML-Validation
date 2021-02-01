using Microsoft.EntityFrameworkCore.Migrations;

namespace EdfXmlValidation.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EdfFieldTypeRestrictions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    EdfFieldType = table.Column<int>(nullable: false),
                    MinValue = table.Column<int>(nullable: true),
                    MaxValue = table.Column<int>(nullable: true),
                    ConcreteValue = table.Column<int>(nullable: true),
                    PossibleChoices = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdfFieldTypeRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EdfFields",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    EdfFieldTypeRestrictionId = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdfFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdfFields_EdfFieldTypeRestrictions_EdfFieldTypeRestrictionId",
                        column: x => x.EdfFieldTypeRestrictionId,
                        principalTable: "EdfFieldTypeRestrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EdfFields_EdfFieldTypeRestrictionId",
                table: "EdfFields",
                column: "EdfFieldTypeRestrictionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdfFields");

            migrationBuilder.DropTable(
                name: "EdfFieldTypeRestrictions");
        }
    }
}