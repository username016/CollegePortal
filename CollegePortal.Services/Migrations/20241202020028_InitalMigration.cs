using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CollegePortal.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "GymRoomBookings",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<int>(type: "INTEGER", nullable: false),
                    studentName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    gymRoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    startTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymRoomBookings", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_GymRoomBookings_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LostAndFound",
                columns: table => new
                {
                    postId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<int>(type: "INTEGER", nullable: false),
                    itemDescription = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    foundDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostAndFound", x => x.postId);
                    table.ForeignKey(
                        name: "FK_LostAndFound_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyRoomBookings",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<int>(type: "INTEGER", nullable: false),
                    studyRoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    startTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyRoomBookings", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_StudyRoomBookings_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutorBookings",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<int>(type: "INTEGER", nullable: false),
                    tutorId = table.Column<int>(type: "INTEGER", nullable: false),
                    startTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorBookings", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_TutorBookings_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "studentId", "name", "password" },
                values: new object[,]
                {
                    { 1, "John Doe", "password123" },
                    { 2, "Jane Smith", "securepass" },
                    { 3, "Mike Johnson", "studentpass" }
                });

            migrationBuilder.InsertData(
                table: "GymRoomBookings",
                columns: new[] { "bookingId", "endTime", "gymRoomId", "startTime", "studentId", "studentName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 4, 0, 27, 43, DateTimeKind.Local).AddTicks(9448), 1, new DateTime(2024, 12, 3, 3, 0, 27, 36, DateTimeKind.Local).AddTicks(3731), 1, "John Doe" },
                    { 2, new DateTime(2024, 12, 4, 9, 0, 27, 44, DateTimeKind.Local).AddTicks(8), 2, new DateTime(2024, 12, 4, 8, 0, 27, 43, DateTimeKind.Local).AddTicks(9995), 2, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "LostAndFound",
                columns: new[] { "postId", "foundDate", "itemDescription", "location", "studentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 28, 18, 0, 27, 45, DateTimeKind.Local).AddTicks(5900), "Blue Backpack", "Library", 1 },
                    { 2, new DateTime(2024, 11, 30, 18, 0, 27, 45, DateTimeKind.Local).AddTicks(6850), "Laptop Charger", "Student Center", 2 }
                });

            migrationBuilder.InsertData(
                table: "StudyRoomBookings",
                columns: new[] { "bookingId", "dateTime", "endTime", "startTime", "studentId", "studyRoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 1, 18, 0, 27, 44, DateTimeKind.Local).AddTicks(8646), new DateTime(2024, 12, 3, 6, 0, 27, 45, DateTimeKind.Local).AddTicks(1103), new DateTime(2024, 12, 3, 4, 0, 27, 45, DateTimeKind.Local).AddTicks(509), 1, 1 },
                    { 2, new DateTime(2024, 12, 1, 18, 0, 27, 45, DateTimeKind.Local).AddTicks(1579), new DateTime(2024, 12, 4, 9, 0, 27, 45, DateTimeKind.Local).AddTicks(1595), new DateTime(2024, 12, 4, 7, 0, 27, 45, DateTimeKind.Local).AddTicks(1591), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "TutorBookings",
                columns: new[] { "bookingId", "dateTime", "endTime", "startTime", "studentId", "tutorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 1, 18, 0, 27, 45, DateTimeKind.Local).AddTicks(8983), new DateTime(2024, 12, 5, 5, 0, 27, 45, DateTimeKind.Local).AddTicks(9836), new DateTime(2024, 12, 5, 4, 0, 27, 45, DateTimeKind.Local).AddTicks(9437), 1, 101 },
                    { 2, new DateTime(2024, 12, 1, 18, 0, 27, 46, DateTimeKind.Local).AddTicks(226), new DateTime(2024, 12, 6, 9, 0, 27, 46, DateTimeKind.Local).AddTicks(239), new DateTime(2024, 12, 6, 8, 0, 27, 46, DateTimeKind.Local).AddTicks(237), 2, 102 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymRoomBookings_studentId",
                table: "GymRoomBookings",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_LostAndFound_studentId",
                table: "LostAndFound",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyRoomBookings_studentId",
                table: "StudyRoomBookings",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorBookings_studentId",
                table: "TutorBookings",
                column: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymRoomBookings");

            migrationBuilder.DropTable(
                name: "LostAndFound");

            migrationBuilder.DropTable(
                name: "StudyRoomBookings");

            migrationBuilder.DropTable(
                name: "TutorBookings");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
