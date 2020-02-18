using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyApp.Data.Migrations
{
    public partial class ratinggs_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AcademyProgramId",
                table: "Ratings",
                column: "AcademyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MentorId",
                table: "Ratings",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SubCategoryId",
                table: "Ratings",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SubjectId",
                table: "Ratings",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AcademyPrograms_AcademyProgramId",
                table: "Ratings",
                column: "AcademyProgramId",
                principalTable: "AcademyPrograms",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Mentors_MentorId",
                table: "Ratings",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Students_StudentId",
                table: "Ratings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_SubCategories_SubCategoryId",
                table: "Ratings",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Subjects_SubjectId",
                table: "Ratings",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AcademyPrograms_AcademyProgramId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Mentors_MentorId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Students_StudentId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_SubCategories_SubCategoryId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Subjects_SubjectId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_AcademyProgramId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_MentorId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_SubCategoryId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_SubjectId",
                table: "Ratings");
        }
    }
}
