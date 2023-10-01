using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRDH.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EarliestPositiveOrderTestSampleCollectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EarliestPositiveOrderTestType = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderTestCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryTests",
                columns: table => new
                {
                    OrderTestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderTestType = table.Column<string>(type: "TEXT", nullable: true),
                    SampleCollectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderTestResult = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryTests", x => x.OrderTestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "LaboratoryTests");
        }
    }
}
