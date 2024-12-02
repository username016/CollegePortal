using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegePortal.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GymRoomBookings",
                keyColumn: "bookingId",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 3, 3, 42, 29, 445, DateTimeKind.Local).AddTicks(2569), new DateTime(2024, 12, 3, 2, 42, 29, 437, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "GymRoomBookings",
                keyColumn: "bookingId",
                keyValue: 2,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 4, 8, 42, 29, 445, DateTimeKind.Local).AddTicks(3126), new DateTime(2024, 12, 4, 7, 42, 29, 445, DateTimeKind.Local).AddTicks(3112) });

            migrationBuilder.UpdateData(
                table: "LostAndFound",
                keyColumn: "postId",
                keyValue: 1,
                column: "foundDate",
                value: new DateTime(2024, 11, 28, 17, 42, 29, 445, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "LostAndFound",
                keyColumn: "postId",
                keyValue: 2,
                column: "foundDate",
                value: new DateTime(2024, 11, 30, 17, 42, 29, 445, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "StudyRoomBookings",
                keyColumn: "bookingId",
                keyValue: 1,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 17, 42, 29, 445, DateTimeKind.Local).AddTicks(5328), new DateTime(2024, 12, 3, 5, 42, 29, 445, DateTimeKind.Local).AddTicks(6166), new DateTime(2024, 12, 3, 3, 42, 29, 445, DateTimeKind.Local).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "StudyRoomBookings",
                keyColumn: "bookingId",
                keyValue: 2,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 17, 42, 29, 445, DateTimeKind.Local).AddTicks(6568), new DateTime(2024, 12, 4, 8, 42, 29, 445, DateTimeKind.Local).AddTicks(6582), new DateTime(2024, 12, 4, 6, 42, 29, 445, DateTimeKind.Local).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "TutorBookings",
                keyColumn: "bookingId",
                keyValue: 1,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 17, 42, 29, 446, DateTimeKind.Local).AddTicks(1657), new DateTime(2024, 12, 5, 4, 42, 29, 446, DateTimeKind.Local).AddTicks(2472), new DateTime(2024, 12, 5, 3, 42, 29, 446, DateTimeKind.Local).AddTicks(2073) });

            migrationBuilder.UpdateData(
                table: "TutorBookings",
                keyColumn: "bookingId",
                keyValue: 2,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 17, 42, 29, 446, DateTimeKind.Local).AddTicks(2987), new DateTime(2024, 12, 6, 8, 42, 29, 446, DateTimeKind.Local).AddTicks(3000), new DateTime(2024, 12, 6, 7, 42, 29, 446, DateTimeKind.Local).AddTicks(2997) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GymRoomBookings",
                keyColumn: "bookingId",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 3, 6, 13, 34, 93, DateTimeKind.Local).AddTicks(9818), new DateTime(2024, 12, 3, 5, 13, 34, 92, DateTimeKind.Local).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "GymRoomBookings",
                keyColumn: "bookingId",
                keyValue: 2,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 4, 11, 13, 34, 94, DateTimeKind.Local).AddTicks(540), new DateTime(2024, 12, 4, 10, 13, 34, 94, DateTimeKind.Local).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "LostAndFound",
                keyColumn: "postId",
                keyValue: 1,
                column: "foundDate",
                value: new DateTime(2024, 11, 28, 20, 13, 34, 94, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "LostAndFound",
                keyColumn: "postId",
                keyValue: 2,
                column: "foundDate",
                value: new DateTime(2024, 11, 30, 20, 13, 34, 94, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "StudyRoomBookings",
                keyColumn: "bookingId",
                keyValue: 1,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 13, 34, 94, DateTimeKind.Local).AddTicks(1702), new DateTime(2024, 12, 3, 8, 13, 34, 94, DateTimeKind.Local).AddTicks(2158), new DateTime(2024, 12, 3, 6, 13, 34, 94, DateTimeKind.Local).AddTicks(1936) });

            migrationBuilder.UpdateData(
                table: "StudyRoomBookings",
                keyColumn: "bookingId",
                keyValue: 2,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 13, 34, 94, DateTimeKind.Local).AddTicks(2377), new DateTime(2024, 12, 4, 11, 13, 34, 94, DateTimeKind.Local).AddTicks(2385), new DateTime(2024, 12, 4, 9, 13, 34, 94, DateTimeKind.Local).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "TutorBookings",
                keyColumn: "bookingId",
                keyValue: 1,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 13, 34, 94, DateTimeKind.Local).AddTicks(4889), new DateTime(2024, 12, 5, 7, 13, 34, 94, DateTimeKind.Local).AddTicks(5329), new DateTime(2024, 12, 5, 6, 13, 34, 94, DateTimeKind.Local).AddTicks(5112) });

            migrationBuilder.UpdateData(
                table: "TutorBookings",
                keyColumn: "bookingId",
                keyValue: 2,
                columns: new[] { "dateTime", "endTime", "startTime" },
                values: new object[] { new DateTime(2024, 12, 1, 20, 13, 34, 94, DateTimeKind.Local).AddTicks(5546), new DateTime(2024, 12, 6, 11, 13, 34, 94, DateTimeKind.Local).AddTicks(5554), new DateTime(2024, 12, 6, 10, 13, 34, 94, DateTimeKind.Local).AddTicks(5552) });
        }
    }
}
