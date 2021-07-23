using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MainProject.Migrations
{
    public partial class StartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sch");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "sch",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CreatedCourses_CreatedByUser_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CreatedByUser_CreatedMaterials_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PassingCourse",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Progress = table.Column<double>(type: "float", maxLength: 12, nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", maxLength: 12, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassingCourses", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Course_PassingCourses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SkillLevel = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CourseEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CreatedSKills_CreatedByUser_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_Courses_CourseEntityId",
                        column: x => x.CourseEntityId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses_UsersSkills_Enrollments",
                schema: "sch",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    MaterialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses_UsersSkills_Enrollments", x => new { x.CoursesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_Courses_UsersSkills_Enrollments_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_UsersSkills_Enrollments_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectronicPublication",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfPublishing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicPublication", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ElectronicPublication_Materials_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternetArticle",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfPublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wiki = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetArticle", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_InternetArticle_Materials_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users_FinishedMaterials_Enrollments",
                schema: "sch",
                columns: table => new
                {
                    FinishedMaterialsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_FinishedMaterials_Enrollments", x => new { x.FinishedMaterialsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Users_FinishedMaterials_Enrollments_Materials_FinishedMaterialsId",
                        column: x => x.FinishedMaterialsId,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_FinishedMaterials_Enrollments_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoResource",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoResource", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_VideoResource_Materials_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users_PassingCourses_Enrollments",
                schema: "sch",
                columns: table => new
                {
                    PassingCoursesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_PassingCourses_Enrollments", x => new { x.PassingCoursesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Users_PassingCourses_Enrollments_PassingCourse_PassingCoursesId",
                        column: x => x.PassingCoursesId,
                        principalSchema: "sch",
                        principalTable: "PassingCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_PassingCourses_Enrollments_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "AdminRole" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "UserRole" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "renekton73@gmail.com", "Admin", "11221122d", 1 },
                    { 2, "Syino@gmail.com", "Syino", "qwerty123", 2 },
                    { 3, "Danya@gmail.com", "Danya", "11221122", 2 },
                    { 4, "Ment@gmail.com", "Ment", "321", 2 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Courses",
                columns: new[] { "Id", "CreatedByUserId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Изучение C#", "Курс С#" },
                    { 2, 1, "Изучение Html", "Курс Html" },
                    { 3, 1, "Изучение Css", "Курс Css" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Materials",
                columns: new[] { "Id", "CreatedUserId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Патерное программирование C#" },
                    { 2, 1, "Основы Html" },
                    { 3, 1, "Метанит" },
                    { 4, 1, "HtmlBox" },
                    { 5, 1, "Основы языка С#" },
                    { 6, 1, "Основы верстки Html" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Skills",
                columns: new[] { "Id", "CourseEntityId", "CreatedUserId", "Name", "SkillLevel" },
                values: new object[,]
                {
                    { 1, null, 1, "C#", 0 },
                    { 2, null, 1, "Html", 0 },
                    { 3, null, 1, "Css", 0 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "ElectronicPublication",
                columns: new[] { "Id", "Authors", "Format", "NumberOfPages", "YearOfPublishing" },
                values: new object[,]
                {
                    { 1, "Daniel,Marine", ".docx", 30, 2011 },
                    { 2, "Urfic,Dasha", ".pdf", 60, 2018 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "InternetArticle",
                columns: new[] { "Id", "DateOfPublication", "Wiki" },
                values: new object[,]
                {
                    { 3, new DateTime(2015, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.metanit.com" },
                    { 4, new DateTime(2018, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.htmlbox.com" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "PassingCourse",
                columns: new[] { "Id", "CourseId", "IsComplete", "Progress", "UserId" },
                values: new object[,]
                {
                    { 1, 1, false, 0.0, 2 },
                    { 2, 2, false, 0.0, 3 },
                    { 3, 3, false, 0.0, 3 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "VideoResource",
                columns: new[] { "Id", "Duration", "Quality" },
                values: new object[,]
                {
                    { 5, new TimeSpan(0, 3, 25, 30, 0), "720р" },
                    { 6, new TimeSpan(0, 1, 15, 15, 0), "1080р" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedByUserId",
                schema: "sch",
                table: "Courses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UsersSkills_Enrollments_MaterialsId",
                schema: "sch",
                table: "Courses_UsersSkills_Enrollments",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CreatedUserId",
                schema: "sch",
                table: "Materials",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PassingCourse_CourseId",
                schema: "sch",
                table: "PassingCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CourseEntityId",
                schema: "sch",
                table: "Skills",
                column: "CourseEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CreatedUserId",
                schema: "sch",
                table: "Skills",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "sch",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FinishedMaterials_Enrollments_UsersId",
                schema: "sch",
                table: "Users_FinishedMaterials_Enrollments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PassingCourses_Enrollments_UsersId",
                schema: "sch",
                table: "Users_PassingCourses_Enrollments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsersSkills_Enrollments_UsersId",
                schema: "sch",
                table: "Users_UsersSkills_Enrollments",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses_UsersSkills_Enrollments",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "ElectronicPublication",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "InternetArticle",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Users_FinishedMaterials_Enrollments",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Users_PassingCourses_Enrollments",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Users_UsersSkills_Enrollments",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "VideoResource",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "PassingCourse",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Materials",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "sch");
        }
    }
}
