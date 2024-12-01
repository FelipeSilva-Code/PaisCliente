using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteCometrix.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEstrutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PAIS",
                columns: table => new
                {
                    PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_NOME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PAIS", x => x.PK_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_PAIS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.PK_ID);
                    table.ForeignKey(
                        name: "FK_TB_CLIENTE_TB_PAIS_FK_PAIS",
                        column: x => x.FK_PAIS,
                        principalTable: "TB_PAIS",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTE_FK_PAIS",
                table: "TB_CLIENTE",
                column: "FK_PAIS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLIENTE");

            migrationBuilder.DropTable(
                name: "TB_PAIS");
        }
    }
}
