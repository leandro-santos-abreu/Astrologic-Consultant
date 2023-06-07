using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_End.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SignModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sign",
                columns: table => new
                {
                    SignId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFinal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sign", x => x.SignId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sign");
        }
    }
}
