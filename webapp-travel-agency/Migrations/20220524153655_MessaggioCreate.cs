using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class MessaggioCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messaggio",
                columns: table => new
                {
                    MessaggioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    cognome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    messaggio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacchettoViaggioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messaggio", x => x.MessaggioId);
                    table.ForeignKey(
                        name: "FK_Messaggio_PacchettoViaggio_PacchettoViaggioId",
                        column: x => x.PacchettoViaggioId,
                        principalTable: "PacchettoViaggio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messaggio_PacchettoViaggioId",
                table: "Messaggio",
                column: "PacchettoViaggioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messaggio");
        }
    }
}
