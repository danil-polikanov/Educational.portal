using Microsoft.EntityFrameworkCore.Migrations;

namespace MainProject.Migrations
{
    public partial class CourseMaterialEnrollmentsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses_Materials_Enrollments",
                schema: "sch");

            migrationBuilder.CreateTable(
                name: "CourseMaterialEnrollments",
                schema: "sch",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaterialEnrollments", x => new { x.MaterialId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseMaterialEnrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMaterialEnrollments_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterialEnrollments_CourseId",
                schema: "sch",
                table: "CourseMaterialEnrollments",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMaterialEnrollments",
                schema: "sch");

            migrationBuilder.CreateTable(
                name: "Courses_Materials_Enrollments",
                schema: "sch",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    MaterialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses_Materials_Enrollments", x => new { x.CoursesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_Courses_Materials_Enrollments_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Materials_Enrollments_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Materials_Enrollments_MaterialsId",
                schema: "sch",
                table: "Courses_Materials_Enrollments",
                column: "MaterialsId");
        }
    }
}
