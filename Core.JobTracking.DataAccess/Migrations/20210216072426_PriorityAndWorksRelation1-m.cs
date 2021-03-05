using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.JobTracking.DataAccess.Migrations
{
    public partial class PriorityAndWorksRelation1m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Works",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_PriorityId",
                table: "Works",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Priorities_PriorityId",
                table: "Works",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Priorities_PriorityId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropIndex(
                name: "IX_Works_PriorityId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Works");
        }
    }
}
