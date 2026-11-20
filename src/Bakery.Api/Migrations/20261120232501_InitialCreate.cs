using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Channel = table.Column<int>(type: "INTEGER", nullable: false),
                    Handle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AnonymisedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DefaultPricePence = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fillings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fillings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekBookings",
                columns: table => new
                {
                    BakeDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    OvenUnitsBooked = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekBookings", x => x.BakeDate);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PickupDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PickupTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DeclineReason = table.Column<int>(type: "INTEGER", nullable: true),
                    DeclineNote = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    QuotedTotalPence = table.Column<long>(type: "INTEGER", nullable: true),
                    QuotedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: true),
                    PaidAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    CancellationFeePence = table.Column<long>(type: "INTEGER", nullable: false),
                    BookedBakeDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    BookedOvenUnits = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SizeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Tiers = table.Column<int>(type: "INTEGER", nullable: false),
                    BasePricePence = table.Column<long>(type: "INTEGER", nullable: false),
                    OvenUnits = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxFillings = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOptions_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    SizeOptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Flavour = table.Column<int>(type: "INTEGER", nullable: false),
                    Occasion = table.Column<int>(type: "INTEGER", nullable: false),
                    OccasionDetail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Inscription = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    ColourTheme = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DesignNotes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    InspoLink = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    BasePricePence = table.Column<long>(type: "INTEGER", nullable: false),
                    OvenUnits = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_SizeOptions_SizeOptionId",
                        column: x => x.SizeOptionId,
                        principalTable: "SizeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SizeOptionParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SizeOptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    PartSizeOptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOptionParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOptionParts_SizeOptions_PartSizeOptionId",
                        column: x => x.PartSizeOptionId,
                        principalTable: "SizeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SizeOptionParts_SizeOptions_SizeOptionId",
                        column: x => x.SizeOptionId,
                        principalTable: "SizeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FillingOrderLine",
                columns: table => new
                {
                    FillingsId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderLineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillingOrderLine", x => new { x.FillingsId, x.OrderLineId });
                    table.ForeignKey(
                        name: "FK_FillingOrderLine_Fillings_FillingsId",
                        column: x => x.FillingsId,
                        principalTable: "Fillings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FillingOrderLine_OrderLines_OrderLineId",
                        column: x => x.OrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderLineId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExtraTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPricePence = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineExtras_ExtraTypes_ExtraTypeId",
                        column: x => x.ExtraTypeId,
                        principalTable: "ExtraTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineExtras_OrderLines_OrderLineId",
                        column: x => x.OrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FillingOrderLine_OrderLineId",
                table: "FillingOrderLine",
                column: "OrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_LineExtras_ExtraTypeId",
                table: "LineExtras",
                column: "ExtraTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineExtras_OrderLineId",
                table: "LineExtras",
                column: "OrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_SizeOptionId",
                table: "OrderLines",
                column: "SizeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupDate",
                table: "Orders",
                column: "PickupDate");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOptionParts_PartSizeOptionId",
                table: "SizeOptionParts",
                column: "PartSizeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOptionParts_SizeOptionId",
                table: "SizeOptionParts",
                column: "SizeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOptions_MenuItemId",
                table: "SizeOptions",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FillingOrderLine");

            migrationBuilder.DropTable(
                name: "LineExtras");

            migrationBuilder.DropTable(
                name: "SizeOptionParts");

            migrationBuilder.DropTable(
                name: "WeekBookings");

            migrationBuilder.DropTable(
                name: "Fillings");

            migrationBuilder.DropTable(
                name: "ExtraTypes");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SizeOptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
