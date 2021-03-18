using Microsoft.EntityFrameworkCore.Migrations;

namespace DevRupt.App.Migrations
{
    public partial class EntityRelationshipUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charges_Folios_FolioId",
                table: "Charges");

            migrationBuilder.DropForeignKey(
                name: "FK_Folios_Reservations_ReservationId",
                table: "Folios");

            migrationBuilder.DropTable(
                name: "RelatedFolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folios",
                table: "Folios");

            migrationBuilder.DropIndex(
                name: "IX_Charges_FolioId",
                table: "Charges");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationId",
                table: "Folios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FolioReservationId",
                table: "Charges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folios",
                table: "Folios",
                columns: new[] { "Id", "ReservationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Charges_FolioId_FolioReservationId",
                table: "Charges",
                columns: new[] { "FolioId", "FolioReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Charges_Folios_FolioId_FolioReservationId",
                table: "Charges",
                columns: new[] { "FolioId", "FolioReservationId" },
                principalTable: "Folios",
                principalColumns: new[] { "Id", "ReservationId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folios_Reservations_ReservationId",
                table: "Folios",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charges_Folios_FolioId_FolioReservationId",
                table: "Charges");

            migrationBuilder.DropForeignKey(
                name: "FK_Folios_Reservations_ReservationId",
                table: "Folios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folios",
                table: "Folios");

            migrationBuilder.DropIndex(
                name: "IX_Charges_FolioId_FolioReservationId",
                table: "Charges");

            migrationBuilder.DropColumn(
                name: "FolioReservationId",
                table: "Charges");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationId",
                table: "Folios",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folios",
                table: "Folios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RelatedFolio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FolioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedFolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedFolio_Folios_FolioId",
                        column: x => x.FolioId,
                        principalTable: "Folios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charges_FolioId",
                table: "Charges",
                column: "FolioId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedFolio_FolioId",
                table: "RelatedFolio",
                column: "FolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charges_Folios_FolioId",
                table: "Charges",
                column: "FolioId",
                principalTable: "Folios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folios_Reservations_ReservationId",
                table: "Folios",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
