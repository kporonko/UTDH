using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetupDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interface",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterfaceName = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Country = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    CameraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResolutionCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResolutionName = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Resolution = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolutionCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InStockCount = table.Column<int>(type: "int", nullable: false),
                    SensorWidth = table.Column<double>(type: "float", nullable: false),
                    SensorHeight = table.Column<double>(type: "float", nullable: false),
                    IsOpticInComplect = table.Column<bool>(type: "bit", nullable: false),
                    MegaPixels = table.Column<double>(type: "float", nullable: false),
                    LCDMount = table.Column<string>(type: "varchar(max)", nullable: false),
                    Microphone = table.Column<string>(type: "varchar(max)", nullable: false),
                    Protection = table.Column<string>(type: "varchar(max)", nullable: false),
                    Supply = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsMacroPhotography = table.Column<bool>(type: "bit", nullable: false),
                    Stabilization = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsRAWSupport = table.Column<bool>(type: "bit", nullable: false),
                    SoundFormat = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsSensorDisplay = table.Column<bool>(type: "bit", nullable: false),
                    ExpositionMode = table.Column<string>(type: "varchar(max)", nullable: false),
                    LCDDiagonal = table.Column<string>(type: "varchar(max)", nullable: false),
                    MaxZoomValue = table.Column<int>(type: "int", nullable: false),
                    ResolutionCategoryId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Camera_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Camera_ResolutionCategory_ResolutionCategoryId",
                        column: x => x.ResolutionCategoryId,
                        principalTable: "ResolutionCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CameraSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraId = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CameraSystem_Camera_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Camera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CameraSystem_System_SystemId",
                        column: x => x.SystemId,
                        principalTable: "System",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterfaceCamera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraId = table.Column<int>(type: "int", nullable: false),
                    InterfaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterfaceCamera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterfaceCamera_Camera_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Camera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterfaceCamera_Interface_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "Interface",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camera_ModelId",
                table: "Camera",
                column: "ModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Camera_ResolutionCategoryId",
                table: "Camera",
                column: "ResolutionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraSystem_CameraId",
                table: "CameraSystem",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraSystem_SystemId",
                table: "CameraSystem",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceCamera_CameraId",
                table: "InterfaceCamera",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_InterfaceCamera_InterfaceId",
                table: "InterfaceCamera",
                column: "InterfaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraSystem");

            migrationBuilder.DropTable(
                name: "InterfaceCamera");

            migrationBuilder.DropTable(
                name: "System");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropTable(
                name: "Interface");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "ResolutionCategory");
        }
    }
}
