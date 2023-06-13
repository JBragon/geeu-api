using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnCreatedByAndUpdatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Report",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProjectStatusLog",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ProjectStatusLog",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExtensionProject",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExtensionProject",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ExtensionProject",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ExtensionProject_Name",
                table: "ExtensionProject",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_Name",
                table: "Course",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExtensionProject_Name",
                table: "ExtensionProject");

            migrationBuilder.DropIndex(
                name: "IX_Course_Name",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProjectStatusLog");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ProjectStatusLog");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExtensionProject");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExtensionProject");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ExtensionProject");
        }
    }
}
