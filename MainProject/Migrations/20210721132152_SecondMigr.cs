using Microsoft.EntityFrameworkCore.Migrations;

namespace MainProject.Migrations
{
    public partial class SecondMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Courses_CourseEntityId",
                schema: "sch",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Users_UsersSkills_Enrollments",
                schema: "sch");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CourseEntityId",
                schema: "sch",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CourseEntityId",
                schema: "sch",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                schema: "sch",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "CourseEntitySkillEntity",
                schema: "sch",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEntitySkillEntity", x => new { x.CoursesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CourseEntitySkillEntity_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEntitySkillEntity_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalSchema: "sch",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                schema: "sch",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.SkillId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "sch",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Skills",
                columns: new[] { "Id", "CreatedUserId", "Name" },
                values: new object[] { 4, 2, "Test" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEntitySkillEntity_SkillsId",
                schema: "sch",
                table: "CourseEntitySkillEntity",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId",
                schema: "sch",
                table: "Enrollments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEntitySkillEntity",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Enrollments",
                schema: "sch");

            migrationBuilder.DeleteData(
                schema: "sch",
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "CourseEntityId",
                schema: "sch",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillLevel",
                schema: "sch",
                table: "Skills",
                type: "int",
                maxLength: 32,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users_UsersSkills_Enrollments",
                schema: "sch",
                columns: table => new
                {
                    UserSkillsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_UsersSkills_Enrollments", x => new { x.UserSkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Users_UsersSkills_Enrollments_Skills_UserSkillsId",
                        column: x => x.UserSkillsId,
                        principalSchema: "sch",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UsersSkills_Enrollments_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CourseEntityId",
                schema: "sch",
                table: "Skills",
                column: "CourseEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsersSkills_Enrollments_UsersId",
                schema: "sch",
                table: "Users_UsersSkills_Enrollments",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Courses_CourseEntityId",
                schema: "sch",
                table: "Skills",
                column: "CourseEntityId",
                principalSchema: "sch",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
