using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalkingpatternsCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialtablesCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientDetails",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectVersionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    DiscountedTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectVersionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectVersionDetails_ClientDetails_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientDetails",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Materials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accessories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalItemsAmounts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalItemsQuantities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialTotal = table.Column<double>(type: "float", nullable: false),
                    AccessoriesTotal = table.Column<double>(type: "float", nullable: false),
                    AdditionalItemsTotal = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilityNameOld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectVersionDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProjectVersionDetails_ProjectVersionDetailsId",
                        column: x => x.ProjectVersionDetailsId,
                        principalTable: "ProjectVersionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Woodwork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accessories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depth = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDetails_ProjectVersionDetails_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectVersionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProjectVersionDetailsId",
                table: "OrderDetails",
                column: "ProjectVersionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVersionDetails_ClientId",
                table: "ProjectVersionDetails",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProjectDetails");

            migrationBuilder.DropTable(
                name: "ProjectVersionDetails");

            migrationBuilder.DropTable(
                name: "ClientDetails");
        }
    }
}
