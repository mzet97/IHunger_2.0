using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IHunger.Services.Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "AddressRestaurants",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "varchar(80)", nullable: false),
                    Number = table.Column<string>(type: "varchar(80)", nullable: false),
                    District = table.Column<string>(type: "varchar(80)", nullable: false),
                    City = table.Column<string>(type: "varchar(80)", nullable: false),
                    County = table.Column<string>(type: "varchar(80)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Latitude = table.Column<string>(type: "varchar(80)", nullable: false),
                    Longitude = table.Column<string>(type: "varchar(80)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressRestaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRestaurants",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRestaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Image = table.Column<string>(type: "varchar(10000)", nullable: false),
                    IdCategoryRestaurant = table.Column<Guid>(type: "uuid", nullable: false),
                    IdAddressRestaurant = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_AddressRestaurants_IdAddressRestaurant",
                        column: x => x.IdAddressRestaurant,
                        principalSchema: "public",
                        principalTable: "AddressRestaurants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Restaurants_CategoryRestaurants_IdCategoryRestaurant",
                        column: x => x.IdCategoryRestaurant,
                        principalSchema: "public",
                        principalTable: "CategoryRestaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantComments",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRestaurant = table.Column<Guid>(type: "uuid", nullable: false),
                    IdComment = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantComments_Restaurants_IdRestaurant",
                        column: x => x.IdRestaurant,
                        principalSchema: "public",
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantProducts",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRestaurant = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProduct = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantProducts_Restaurants_IdRestaurant",
                        column: x => x.IdRestaurant,
                        principalSchema: "public",
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantComments_IdRestaurant",
                schema: "public",
                table: "RestaurantComments",
                column: "IdRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantProducts_IdRestaurant",
                schema: "public",
                table: "RestaurantProducts",
                column: "IdRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_IdAddressRestaurant",
                schema: "public",
                table: "Restaurants",
                column: "IdAddressRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_IdCategoryRestaurant",
                schema: "public",
                table: "Restaurants",
                column: "IdCategoryRestaurant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantComments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RestaurantProducts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Restaurants",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AddressRestaurants",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CategoryRestaurants",
                schema: "public");
        }
    }
}
