using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class KludgeWithoutClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientOrders_Clients_ClientId",
                table: "ClientOrders");

            migrationBuilder.DropIndex(
                name: "IX_ClientOrders_ClientId",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientOrders");

            migrationBuilder.AddColumn<string>(
                name: "ClientPhone",
                table: "ClientOrders",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientPhone",
                table: "ClientOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "ClientOrders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_ClientId",
                table: "ClientOrders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientOrders_Clients_ClientId",
                table: "ClientOrders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
