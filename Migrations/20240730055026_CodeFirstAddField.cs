using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_DocPro_DMS.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstAddField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Students_Info",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "Students_Info");
        }
    }
}
