using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration_EventsCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsCore",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsCore", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "EventsCore",
                columns: new[] { "Key", "ProjectId", "TopicId" },
                values: new object[] { Guid.NewGuid(), "project123456", "core-song123456" }
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsCore");


        }
    }
}
