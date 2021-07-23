using Microsoft.EntityFrameworkCore.Migrations;

namespace MainProject.Migrations
{
    public partial class CourseSkillEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Skills_SkillId",
                schema: "sch",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_UserId",
                schema: "sch",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "CourseEntitySkillEntity",
                schema: "sch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                schema: "sch",
                table: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                schema: "sch",
                newName: "SkillUserEnrollments",
                newSchema: "sch");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_UserId",
                schema: "sch",
                table: "SkillUserEnrollments",
                newName: "IX_SkillUserEnrollments_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillUserEnrollments",
                schema: "sch",
                table: "SkillUserEnrollments",
                columns: new[] { "SkillId", "UserId" });

            migrationBuilder.CreateTable(
                name: "SkillCourseEntrollments",
                schema: "sch",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    RequirementLevel = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCourseEntrollments", x => new { x.CourseId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_SkillCourseEntrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillCourseEntrollments_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "sch",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "SkillCourseEntrollments",
                columns: new[] { "CourseId", "SkillId", "RequirementLevel" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SkillCourseEntrollments_SkillId",
                schema: "sch",
                table: "SkillCourseEntrollments",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUserEnrollments_Skills_SkillId",
                schema: "sch",
                table: "SkillUserEnrollments",
                column: "SkillId",
                principalSchema: "sch",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUserEnrollments_Users_UserId",
                schema: "sch",
                table: "SkillUserEnrollments",
                column: "UserId",
                principalSchema: "sch",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillUserEnrollments_Skills_SkillId",
                schema: "sch",
                table: "SkillUserEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillUserEnrollments_Users_UserId",
                schema: "sch",
                table: "SkillUserEnrollments");

            migrationBuilder.DropTable(
                name: "SkillCourseEntrollments",
                schema: "sch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillUserEnrollments",
                schema: "sch",
                table: "SkillUserEnrollments");

            migrationBuilder.RenameTable(
                name: "SkillUserEnrollments",
                schema: "sch",
                newName: "Enrollments",
                newSchema: "sch");

            migrationBuilder.RenameIndex(
                name: "IX_SkillUserEnrollments_UserId",
                schema: "sch",
                table: "Enrollments",
                newName: "IX_Enrollments_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                schema: "sch",
                table: "Enrollments",
                columns: new[] { "SkillId", "UserId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseEntitySkillEntity_SkillsId",
                schema: "sch",
                table: "CourseEntitySkillEntity",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Skills_SkillId",
                schema: "sch",
                table: "Enrollments",
                column: "SkillId",
                principalSchema: "sch",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_UserId",
                schema: "sch",
                table: "Enrollments",
                column: "UserId",
                principalSchema: "sch",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
