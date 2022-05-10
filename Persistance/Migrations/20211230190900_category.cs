using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoping.Persistance.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categores",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryCategory_Id = table.Column<int>(type: "int", nullable: true),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categores", x => x.Category_Id);
                    table.ForeignKey(
                        name: "FK_Categores_Categores_ParentCategoryCategory_Id",
                        column: x => x.ParentCategoryCategory_Id,
                        principalTable: "Categores",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categores_ParentCategoryCategory_Id",
                table: "Categores",
                column: "ParentCategoryCategory_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categores");
        }
    }
}
