using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bakery.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExtraTypes",
                columns: new[] { "Id", "DefaultPricePence", "Name" },
                values: new object[,]
                {
                    { 1, null, "Topper" },
                    { 2, null, "Fondant figure" },
                    { 3, null, "Fresh flowers" },
                    { 4, null, "Chocolates" },
                    { 5, null, "Fake flowers" }
                });

            migrationBuilder.InsertData(
                table: "Fillings",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Chocolate" },
                    { 2, true, "Caramel" },
                    { 3, true, "Lemon curd" },
                    { 4, true, "Oreo" },
                    { 5, true, "Lotus biscoff" },
                    { 6, true, "Kinderbueno" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cupcakes" },
                    { 2, "Bentocake" },
                    { 3, "Round cake" },
                    { 4, "Heart cake" }
                });

            migrationBuilder.InsertData(
                table: "SizeOptions",
                columns: new[] { "Id", "BasePricePence", "IsActive", "MaxFillings", "MenuItemId", "Name", "OvenUnits", "Tiers" },
                values: new object[,]
                {
                    { 1, 350L, true, 1, 1, "1 cupcake", 1, 1 },
                    { 2, 2500L, true, 6, 1, "6 cupcakes", 0, 1 },
                    { 3, 4500L, true, 6, 1, "12 cupcakes", 0, 1 },
                    { 4, 2500L, true, 1, 2, "Bentocake", 5, 1 },
                    { 5, 3500L, true, 3, 2, "Bentocake & 2 cupcakes", 0, 1 },
                    { 6, 5000L, true, 6, 2, "Bentocake & 5 cupcakes", 0, 1 },
                    { 7, 6000L, true, 6, 2, "Bentocake & 8 cupcakes", 0, 1 },
                    { 8, 6500L, true, 1, 3, "Round cake 8-10 servings", 20, 1 },
                    { 9, 8000L, true, 1, 3, "Round cake 12-15 servings", 20, 1 },
                    { 10, 12000L, true, 1, 3, "Round cake 18-22 servings", 30, 1 },
                    { 11, 15000L, true, 1, 3, "Round cake 24-27 servings", 30, 1 },
                    { 12, 7500L, true, 1, 4, "Heart cake 10-15 servings", 20, 1 },
                    { 13, 14500L, true, 1, 4, "Heart cake 20-25 servings", 30, 1 },
                    { 14, 20000L, true, 2, 3, "Round cake 30-35 servings", 0, 2 },
                    { 15, 25000L, true, 2, 3, "Round cake 40-45 servings", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "SizeOptionParts",
                columns: new[] { "Id", "PartSizeOptionId", "Quantity", "SizeOptionId" },
                values: new object[,]
                {
                    { 1, 1, 6, 2 },
                    { 2, 1, 12, 3 },
                    { 3, 4, 1, 5 },
                    { 4, 1, 2, 5 },
                    { 5, 4, 1, 6 },
                    { 6, 1, 5, 6 },
                    { 7, 4, 1, 7 },
                    { 8, 1, 8, 7 },
                    { 9, 8, 1, 14 },
                    { 10, 10, 1, 14 },
                    { 11, 9, 1, 15 },
                    { 12, 11, 1, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExtraTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fillings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fillings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fillings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fillings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fillings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fillings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SizeOptionParts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SizeOptions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
