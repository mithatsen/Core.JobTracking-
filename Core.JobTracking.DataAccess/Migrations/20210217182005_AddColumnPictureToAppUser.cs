using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.JobTracking.DataAccess.Migrations
{
    public partial class AddColumnPictureToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Priorities_PriorityId",
                table: "Works");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Priorities_PriorityId",
                table: "Works",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Priorities_PriorityId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Works",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Priorities_PriorityId",
                table: "Works",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
