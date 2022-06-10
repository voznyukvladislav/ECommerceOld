using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class ProductAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presets_Attributes_Attributes_AttributeId",
                table: "Presets_Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Presets_Attributes_Presets_PresetId",
                table: "Presets_Attributes");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presets_Attributes",
                table: "Presets_Attributes");

            migrationBuilder.RenameTable(
                name: "Presets_Attributes",
                newName: "Preset_Attributes");

            migrationBuilder.RenameIndex(
                name: "IX_Presets_Attributes_PresetId",
                table: "Preset_Attributes",
                newName: "IX_Preset_Attributes_PresetId");

            migrationBuilder.RenameIndex(
                name: "IX_Presets_Attributes_AttributeId",
                table: "Preset_Attributes",
                newName: "IX_Preset_Attributes_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preset_Attributes",
                table: "Preset_Attributes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Product_Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Attributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Attributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Attributes_AttributeId",
                table: "Product_Attributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Attributes_ProductId",
                table: "Product_Attributes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preset_Attributes_Attributes_AttributeId",
                table: "Preset_Attributes",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Preset_Attributes_Presets_PresetId",
                table: "Preset_Attributes",
                column: "PresetId",
                principalTable: "Presets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preset_Attributes_Attributes_AttributeId",
                table: "Preset_Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Preset_Attributes_Presets_PresetId",
                table: "Preset_Attributes");

            migrationBuilder.DropTable(
                name: "Product_Attributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preset_Attributes",
                table: "Preset_Attributes");

            migrationBuilder.RenameTable(
                name: "Preset_Attributes",
                newName: "Presets_Attributes");

            migrationBuilder.RenameIndex(
                name: "IX_Preset_Attributes_PresetId",
                table: "Presets_Attributes",
                newName: "IX_Presets_Attributes_PresetId");

            migrationBuilder.RenameIndex(
                name: "IX_Preset_Attributes_AttributeId",
                table: "Presets_Attributes",
                newName: "IX_Presets_Attributes_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presets_Attributes",
                table: "Presets_Attributes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Val = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Values_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Values_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Values_AttributeId",
                table: "Values",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Values_ProductId",
                table: "Values",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presets_Attributes_Attributes_AttributeId",
                table: "Presets_Attributes",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presets_Attributes_Presets_PresetId",
                table: "Presets_Attributes",
                column: "PresetId",
                principalTable: "Presets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
