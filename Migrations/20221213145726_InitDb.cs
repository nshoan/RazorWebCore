using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Bogus;
using RazorWeb6.Models;
#nullable disable

namespace RazorWeb6.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            Randomizer.Seed = new Random(65653458);

            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(x => x.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticle.RuleFor(x => x.Created, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 7, 30)));
            fakerArticle.RuleFor(x => x.Content, f => f.Lorem.Paragraphs(1, 4));



            for (int i = 0; i < 150; i++)
            {
                Article article = fakerArticle.Generate();
                migrationBuilder.InsertData("Article", new[] { "Title", "Created", "Content" }, new object[] { article.Title, article.Created, article.Content });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
