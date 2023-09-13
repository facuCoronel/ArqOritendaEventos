using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class createTableEventsCore_ApiUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsCore_ApiUrl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventCoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsCore_ApiUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsCore_ApiUrl_EventsCore_EventCoreId",
                        column: x => x.EventCoreId,
                        principalTable: "EventsCore",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsCore_ApiUrl_EventCoreId",
                table: "EventsCore_ApiUrl",
                column: "EventCoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsCore_ApiUrl");
        }
    }
}
