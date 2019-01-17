using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Tot.Infra.Persistence.Migrations
{
    public partial class Tot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "dbo");

            migrationBuilder.CreateTable(
                "Collaborator",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Collaborator", x => x.id); });

            migrationBuilder.CreateTable(
                "Group",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Group", x => x.id); });

            migrationBuilder.CreateTable(
                "Feedback",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 280, nullable: false),
                    group_id = table.Column<int>(nullable: false),
                    creation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        "FK_Feedback_Group_group_id",
                        x => x.group_id,
                        principalSchema: "dbo",
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Role",
                schema: "dbo",
                columns: table => new
                {
                    collaborator_id = table.Column<int>(nullable: false),
                    group_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => new { x.collaborator_id, x.group_id });
                    table.ForeignKey(
                        "FK_Role_Collaborator_collaborator_id",
                        x => x.collaborator_id,
                        principalSchema: "dbo",
                        principalTable: "Collaborator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Role_Group_group_id",
                        x => x.group_id,
                        principalSchema: "dbo",
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Feedback_group_id",
                schema: "dbo",
                table: "Feedback",
                column: "group_id");

            migrationBuilder.CreateIndex(
                "IX_Role_group_id",
                schema: "dbo",
                table: "Role",
                column: "group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Feedback",
                "dbo");

            migrationBuilder.DropTable(
                "Role",
                "dbo");

            migrationBuilder.DropTable(
                "Collaborator",
                "dbo");

            migrationBuilder.DropTable(
                "Group",
                "dbo");
        }
    }
}