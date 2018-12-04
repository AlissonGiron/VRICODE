using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VRICODE.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    NidClass = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamClass = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.NidClass);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    NidProblem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesTitle = table.Column<string>(maxLength: 60, nullable: true),
                    DesProblem = table.Column<string>(maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.NidProblem);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    NidUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamUser = table.Column<string>(nullable: true),
                    DesEmail = table.Column<string>(maxLength: 256, nullable: true),
                    DesPassword = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.NidUser);
                });

            migrationBuilder.CreateTable(
                name: "ProblemClasses",
                columns: table => new
                {
                    NidProblem = table.Column<int>(nullable: false),
                    NidClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemClasses", x => new { x.NidProblem, x.NidClass });
                    table.ForeignKey(
                        name: "FK_ProblemClasses_Classes_NidClass",
                        column: x => x.NidClass,
                        principalTable: "Classes",
                        principalColumn: "NidClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemClasses_Problems_NidProblem",
                        column: x => x.NidProblem,
                        principalTable: "Problems",
                        principalColumn: "NidProblem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTests",
                columns: table => new
                {
                    NidProblemTest = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NidProblem = table.Column<int>(nullable: false),
                    DesTestInput = table.Column<string>(maxLength: 512, nullable: true),
                    DesTestExpectedOutput = table.Column<string>(maxLength: 512, nullable: true),
                    FlgVisibleToUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTests", x => x.NidProblemTest);
                    table.ForeignKey(
                        name: "FK_ProblemTests_Problems_NidProblem",
                        column: x => x.NidProblem,
                        principalTable: "Problems",
                        principalColumn: "NidProblem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemUsers",
                columns: table => new
                {
                    NidProblem = table.Column<int>(nullable: false),
                    NidUser = table.Column<int>(nullable: false),
                    QtyTries = table.Column<int>(nullable: false),
                    FlgProblemCleared = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemUsers", x => new { x.NidProblem, x.NidUser });
                    table.ForeignKey(
                        name: "FK_ProblemUsers_Problems_NidProblem",
                        column: x => x.NidProblem,
                        principalTable: "Problems",
                        principalColumn: "NidProblem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemUsers_Users_NidUser",
                        column: x => x.NidUser,
                        principalTable: "Users",
                        principalColumn: "NidUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClasses",
                columns: table => new
                {
                    NidUser = table.Column<int>(nullable: false),
                    NidClass = table.Column<int>(nullable: false),
                    UserClassPrivilege = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClasses", x => new { x.NidUser, x.NidClass });
                    table.ForeignKey(
                        name: "FK_UserClasses_Classes_NidClass",
                        column: x => x.NidClass,
                        principalTable: "Classes",
                        principalColumn: "NidClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClasses_Users_NidUser",
                        column: x => x.NidUser,
                        principalTable: "Users",
                        principalColumn: "NidUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemClasses_NidClass",
                table: "ProblemClasses",
                column: "NidClass");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemTests_NidProblem",
                table: "ProblemTests",
                column: "NidProblem");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemUsers_NidUser",
                table: "ProblemUsers",
                column: "NidUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserClasses_NidClass",
                table: "UserClasses",
                column: "NidClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemClasses");

            migrationBuilder.DropTable(
                name: "ProblemTests");

            migrationBuilder.DropTable(
                name: "ProblemUsers");

            migrationBuilder.DropTable(
                name: "UserClasses");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
