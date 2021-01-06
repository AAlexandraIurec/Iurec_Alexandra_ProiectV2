using Microsoft.EntityFrameworkCore.Migrations;

namespace Iurec_Alexandra_ProiectV2.Migrations
{
    public partial class CreateOurService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OurServiceID",
                table: "Contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OurService",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(nullable: true),
                    ServicePrice = table.Column<decimal>(type: "decimal(6, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurService", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_OurServiceID",
                table: "Contract",
                column: "OurServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_OurService_OurServiceID",
                table: "Contract",
                column: "OurServiceID",
                principalTable: "OurService",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_OurService_OurServiceID",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "OurService");

            migrationBuilder.DropIndex(
                name: "IX_Contract_OurServiceID",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "OurServiceID",
                table: "Contract");
        }
    }
}
