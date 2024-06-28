using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentMarketplace.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Rooms = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(99)", maxLength: 99, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(999)", maxLength: 999, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.CheckConstraint("CK_Apartment_Price", "\"Price\" > 0");
                    table.CheckConstraint("CK_Apartment_Rooms", "\"Rooms\" > 0");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
