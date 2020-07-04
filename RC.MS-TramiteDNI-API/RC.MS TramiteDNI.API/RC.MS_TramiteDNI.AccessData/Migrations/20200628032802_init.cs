using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.MS_TramiteDNI.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TramiteDNIs",
                columns: table => new
                {
                    TramiteDNIid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteDNIs", x => x.TramiteDNIid);
                });

            migrationBuilder.CreateTable(
                name: "Extranjeros",
                columns: table => new
                {
                    ExtranjeroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisOrigen = table.Column<string>(maxLength: 45, nullable: false),
                    TramiteDNIid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extranjeros", x => x.ExtranjeroId);
                    table.ForeignKey(
                        name: "FK_Extranjeros_TramiteDNIs_TramiteDNIid",
                        column: x => x.TramiteDNIid,
                        principalTable: "TramiteDNIs",
                        principalColumn: "TramiteDNIid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nacimientos",
                columns: table => new
                {
                    NacimientoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TramiteRecienNacidoId = table.Column<int>(nullable: false),
                    TramiteDNIid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacimientos", x => x.NacimientoId);
                    table.ForeignKey(
                        name: "FK_Nacimientos_TramiteDNIs_TramiteDNIid",
                        column: x => x.TramiteDNIid,
                        principalTable: "TramiteDNIs",
                        principalColumn: "TramiteDNIid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NuevosEjemplares",
                columns: table => new
                {
                    NuevoEjemplarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 45, nullable: false),
                    TramiteDNIid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NuevosEjemplares", x => x.NuevoEjemplarId);
                    table.ForeignKey(
                        name: "FK_NuevosEjemplares_TramiteDNIs_TramiteDNIid",
                        column: x => x.TramiteDNIid,
                        principalTable: "TramiteDNIs",
                        principalColumn: "TramiteDNIid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extranjeros_TramiteDNIid",
                table: "Extranjeros",
                column: "TramiteDNIid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nacimientos_TramiteDNIid",
                table: "Nacimientos",
                column: "TramiteDNIid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NuevosEjemplares_TramiteDNIid",
                table: "NuevosEjemplares",
                column: "TramiteDNIid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extranjeros");

            migrationBuilder.DropTable(
                name: "Nacimientos");

            migrationBuilder.DropTable(
                name: "NuevosEjemplares");

            migrationBuilder.DropTable(
                name: "TramiteDNIs");
        }
    }
}
