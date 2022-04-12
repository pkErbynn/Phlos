using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phlosales.API.Migrations
{
    public partial class InitWithGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdOrders",
                columns: table => new
                {
                    ProdOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdOrders", x => x.ProdOrderId);
                });

            migrationBuilder.InsertData(
                table: "ProdOrders",
                columns: new[] { "ProdOrderId", "CustomerName", "Price", "ProductName" },
                values: new object[,]
                {
                    { new Guid("48534156-4923-45c3-9e3d-46736be70ce4"), "Raph", 25.0, "airpod" },
                    { new Guid("518de724-fcb4-468b-86d2-774f7b899eeb"), "Chris", 20.0, "laptop" },
                    { new Guid("6f45ee91-4c47-4ace-8146-22c5fd564328"), "John", 20.0, "phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdOrders");
        }
    }
}
