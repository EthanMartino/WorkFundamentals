using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkFundamentals.Data.Migrations
{
    public partial class AddedSMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendSms",
                columns: table => new
                {
                    SmsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _yourMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendSms", x => x.SmsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendSms");
        }
    }
}
