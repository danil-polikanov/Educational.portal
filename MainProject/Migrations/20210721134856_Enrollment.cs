using Microsoft.EntityFrameworkCore.Migrations;

namespace MainProject.Migrations
{
    public partial class Enrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UsersSkills_Enrollments_Courses_CoursesId",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_UsersSkills_Enrollments_Materials_MaterialsId",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses_UsersSkills_Enrollments",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments");

            migrationBuilder.RenameTable(
                name: "Courses_UsersSkills_Enrollments",
                schema: "sch",
                newName: "Courses_Materials_Enrollments",
                newSchema: "sch");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_UsersSkills_Enrollments_MaterialsId",
                schema: "sch",
                table: "Courses_Materials_Enrollments",
                newName: "IX_Courses_Materials_Enrollments_MaterialsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses_Materials_Enrollments",
                schema: "sch",
                table: "Courses_Materials_Enrollments",
                columns: new[] { "CoursesId", "MaterialsId" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Enrollments",
                columns: new[] { "SkillId", "UserId", "Level" },
                values: new object[] { 4, 4, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Materials_Enrollments_Courses_CoursesId",
                schema: "sch",
                table: "Courses_Materials_Enrollments",
                column: "CoursesId",
                principalSchema: "sch",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Materials_Enrollments_Materials_MaterialsId",
                schema: "sch",
                table: "Courses_Materials_Enrollments",
                column: "MaterialsId",
                principalSchema: "sch",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Materials_Enrollments_Courses_CoursesId",
                schema: "sch",
                table: "Courses_Materials_Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Materials_Enrollments_Materials_MaterialsId",
                schema: "sch",
                table: "Courses_Materials_Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses_Materials_Enrollments",
                schema: "sch",
                table: "Courses_Materials_Enrollments");

            migrationBuilder.DeleteData(
                schema: "sch",
                table: "Enrollments",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.RenameTable(
                name: "Courses_Materials_Enrollments",
                schema: "sch",
                newName: "Courses_UsersSkills_Enrollments",
                newSchema: "sch");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Materials_Enrollments_MaterialsId",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments",
                newName: "IX_Courses_UsersSkills_Enrollments_MaterialsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses_UsersSkills_Enrollments",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments",
                columns: new[] { "CoursesId", "MaterialsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UsersSkills_Enrollments_Courses_CoursesId",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments",
                column: "CoursesId",
                principalSchema: "sch",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_UsersSkills_Enrollments_Materials_MaterialsId",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments",
                column: "MaterialsId",
                principalSchema: "sch",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
