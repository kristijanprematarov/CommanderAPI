using Microsoft.EntityFrameworkCore.Migrations;

namespace Commander.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowTo = table.Column<string>(nullable: false),
                    CommandLine = table.Column<string>(nullable: false),
                    Platform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandLine", "HowTo", "Platform" },
                values: new object[,]
                {
                    { 1, "git status", "View status of git repository", "Git" },
                    { 2, "ls -a", "View all files in folder including hidden", "Git" },
                    { 3, "git add .", "Stage all files in directory for commit", "Git" },
                    { 4, "git diff", "View staged files for commit", "Git" },
                    { 5, "git commit -m \"the message goes in here\" ", "Commit with message", "Git" },
                    { 6, "git push", "Push to git", "Git" },
                    { 7, "git reset --hard HEAD~1", "Remove last commit", "Git" },
                    { 8, "add-migration \"name of migration goes in here\"", "Add migration", "EF Core" },
                    { 9, "remove-migration", "Remove last migration", "EF Core" },
                    { 10, "update-database -verbose", "Update Database", "EF Core" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");
        }
    }
}
