using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleAPI.Migrations
{
   
    public partial class AddLastModifiedToYourEntity : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
            name: "LastModified",
            table: "Stocks",
            nullable: false,
            defaultValue: DateTime.UtcNow);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "LastModified",
            table: "Stocks");
        }
    }
}
