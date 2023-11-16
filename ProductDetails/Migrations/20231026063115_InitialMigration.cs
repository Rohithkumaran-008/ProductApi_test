using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductDetails.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    indentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    docNo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    transferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fromUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cencel = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issueId = table.Column<int>(type: "int", nullable: false),
                    AuId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cancel = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueDetails_Issues_issueId",
                        column: x => x.issueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueDetails_issueId",
                table: "IssueDetails",
                column: "issueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueDetails");

            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}
