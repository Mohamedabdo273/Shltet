using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shltet.Migrations
{
    /// <inheritdoc />
    public partial class shelterStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_ShelterAccountId1",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ShelterAccountId1",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "ShelterAccountId1",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "ShelterId",
                table: "SupportRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShelterId",
                table: "PetCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShelterId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdoptionRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdopterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionRequest_AspNetUsers_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdoptionRequest_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdoptionRequest_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_ShelterId",
                table: "SupportRequests",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ShelterAccountId",
                table: "Pets",
                column: "ShelterAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PetCategories_ShelterId",
                table: "PetCategories",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShelterId",
                table: "AspNetUsers",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequest_AdopterId",
                table: "AdoptionRequest",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequest_PetId",
                table: "AdoptionRequest",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequest_ShelterId",
                table: "AdoptionRequest",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shelters_ShelterId",
                table: "AspNetUsers",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetCategories_Shelters_ShelterId",
                table: "PetCategories",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Shelters_ShelterAccountId",
                table: "Pets",
                column: "ShelterAccountId",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportRequests_Shelters_ShelterId",
                table: "SupportRequests",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shelters_ShelterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PetCategories_Shelters_ShelterId",
                table: "PetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Shelters_ShelterAccountId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportRequests_Shelters_ShelterId",
                table: "SupportRequests");

            migrationBuilder.DropTable(
                name: "AdoptionRequest");

            migrationBuilder.DropIndex(
                name: "IX_SupportRequests_ShelterId",
                table: "SupportRequests");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ShelterAccountId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_PetCategories_ShelterId",
                table: "PetCategories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShelterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "SupportRequests");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "PetCategories");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Shelters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShelterAccountId1",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ShelterAccountId1",
                table: "Pets",
                column: "ShelterAccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_ShelterAccountId1",
                table: "Pets",
                column: "ShelterAccountId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
