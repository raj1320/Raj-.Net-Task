using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTMS.Migrations
{
    /// <inheritdoc />
    public partial class removeGeneralScoreFromEnrolledEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "EnrolledEmployees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "EnrolledEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
