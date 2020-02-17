using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_ContosoUniversity.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course assignment_Course_CourseID",
                table: "Course assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Course assignment_Instructor_InstructorID",
                table: "Course assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Office assignment_Instructor_InstructorID",
                table: "Office assignment");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office assignment",
                table: "Office assignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course assignment",
                table: "Course assignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Office assignment",
                newName: "OfficeAssignment");

            migrationBuilder.RenameTable(
                name: "Course assignment",
                newName: "CourseAssignment");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Course assignment_InstructorID",
                table: "CourseAssignment",
                newName: "IX_CourseAssignment_InstructorID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Person",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeAssignment",
                table: "OfficeAssignment",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment",
                columns: new[] { "CourseID", "InstructorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Course_CourseID",
                table: "CourseAssignment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Person_InstructorID",
                table: "CourseAssignment",
                column: "InstructorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Person_InstructorID",
                table: "Department",
                column: "InstructorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Person_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Person_InstructorID",
                table: "OfficeAssignment",
                column: "InstructorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Course_CourseID",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Person_InstructorID",
                table: "CourseAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Person_InstructorID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Person_StudentID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_Person_InstructorID",
                table: "OfficeAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeAssignment",
                table: "OfficeAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseAssignment",
                table: "CourseAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "OfficeAssignment",
                newName: "Office assignment");

            migrationBuilder.RenameTable(
                name: "CourseAssignment",
                newName: "Course assignment");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssignment_InstructorID",
                table: "Course assignment",
                newName: "IX_Course assignment_InstructorID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Student",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office assignment",
                table: "Office assignment",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course assignment",
                table: "Course assignment",
                columns: new[] { "CourseID", "InstructorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course assignment_Course_CourseID",
                table: "Course assignment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course assignment_Instructor_InstructorID",
                table: "Course assignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_InstructorID",
                table: "Department",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Office assignment_Instructor_InstructorID",
                table: "Office assignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
