using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBulbProject.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.FormId);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxRating = table.Column<int>(type: "int", nullable: false),
                    FormID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Forms_FormID",
                        column: x => x.FormID,
                        principalTable: "Forms",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmisionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RatingValue = table.Column<int>(type: "int", nullable: false),
                    FieldID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldResponses_Fields_FieldID",
                        column: x => x.FieldID,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldResponses_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "FormId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldResponses_FieldID",
                table: "FieldResponses",
                column: "FieldID");

            migrationBuilder.CreateIndex(
                name: "IX_FieldResponses_FormId",
                table: "FieldResponses",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldResponses_SubmisionID",
                table: "FieldResponses",
                column: "SubmisionID");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FormID",
                table: "Fields",
                column: "FormID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldResponses");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
