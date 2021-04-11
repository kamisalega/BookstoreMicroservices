using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Services.BookCatalog.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfDeath = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), new DateTimeOffset(new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "Stephen", "King" },
                    { new Guid("76053df4-6687-4353-8937-b45556748abe"), new DateTimeOffset(new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "George", "RR Martin" },
                    { new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"), new DateTimeOffset(new DateTime(1960, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "Neil", "Gaiman" },
                    { new Guid("578359b7-1967-41d6-8b87-64ab7605587e"), new DateTimeOffset(new DateTime(1958, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "Tom", "Lanoye" },
                    { new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"), new DateTimeOffset(new DateTime(1952, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "Douglas", "Adams" },
                    { new Guid("a1da1d8e-1988-4634-b538-a01709477b77"), new DateTimeOffset(new DateTime(1974, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "Jens", "Lapidus" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), "Horror" },
                    { new Guid("6900926a-aa18-4cf6-a62d-09ed26263d00"), "Fantasy" },
                    { new Guid("8e6bc666-a459-4083-96ea-4654afe99d83"), "Various" },
                    { new Guid("28b53ff0-0547-40c6-884c-9646cc4c3906"), "Science Fiction" },
                    { new Guid("5d1cd43d-5ff6-44dd-96d1-d06806795d02"), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Date", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"), new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTime(2021, 3, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(3261), "The Shining is a horror novel by American author Stephen King. Published in 1977, it is King's third published novel and first hardback bestseller: the success of the book firmly established King as a preeminent author in the horror genre. ", "http://prodimage.images-bn.com/pimages/9780345806789_p0_v2_s1200x630.jpg", 49.990000000000002, "The Shining" },
                    { new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"), new Guid("a1da1d8e-1988-4634-b538-a01709477b77"), new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTime(2021, 6, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6511), "The Stand is a post-apocalyptic horror/fantasy novel by American author Stephen King. It expands upon the scenario of his earlier short story 'Night Surf' and outlines the total breakdown of society after the accidental release of a strain of influenza that had been modified for biological warfare causes an apocalyptic pandemic which kills off the majority of the world's human population.", "http://upload.wikimedia.org/wikipedia/en/thumb/5/5a/It_cover.jpg/220px-It_cover.jpg", 49.990000000000002, "The Stand" },
                    { new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"), new Guid("a1da1d8e-1988-4634-b538-a01709477b77"), new Guid("6900926a-aa18-4cf6-a62d-09ed26263d00"), new DateTime(2021, 4, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6461), "Misery is a 1987 psychological horror novel by Stephen King. This novel was nominated for the World Fantasy Award for Best Novel in 1988, and was later made into a Hollywood film and an off-Broadway play of the same name.", "http://2.bp.blogspot.com/-esMqeTYoTvo/Vd3uKSb0NqI/AAAAAAAACJA/C9LkuKaBoVI/s1600/misery.jpg", 49.990000000000002, "Misery" },
                    { new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"), new Guid("76053df4-6687-4353-8937-b45556748abe"), new Guid("6900926a-aa18-4cf6-a62d-09ed26263d00"), new DateTime(2021, 7, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6517), "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin. It was first published on August 1, 1996.", "http://upload.wikimedia.org/wikipedia/en/thumb/5/5a/It_cover.jpg/220px-It_cover.jpg", 49.990000000000002, "A Game of Thrones" },
                    { new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"), new Guid("76053df4-6687-4353-8937-b45556748abe"), new Guid("6900926a-aa18-4cf6-a62d-09ed26263d00"), new DateTime(2021, 9, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6529), "A Dance with Dragons is the fifth of seven planned novels in the epic fantasy series A Song of Ice and Fire by American author George R. R. Martin.", "http://cdn-lubimyczytac.pl/upload/books/166000/166640/157958-352x500.jpg", 49.990000000000002, "A Dance with Dragons" },
                    { new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"), new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"), new Guid("6900926a-aa18-4cf6-a62d-09ed26263d00"), new DateTime(2021, 10, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6536), "American Gods is a Hugo and Nebula Award-winning novel by English author Neil Gaiman. The novel is a blend of Americana, fantasy, and various strands of ancient and modern mythology, all centering on the mysterious and taciturn Shadow.", "http://cdn-lubimyczytac.pl/upload/books/4876000/4876555/715391-352x500.jpg", 49.990000000000002, "American Gods" },
                    { new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"), new Guid("76053df4-6687-4353-8937-b45556748abe"), new Guid("8e6bc666-a459-4083-96ea-4654afe99d83"), new DateTime(2021, 8, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6523), "Forthcoming 6th novel in A Song of Ice and Fire.", "http://cdn-lubimyczytac.pl/upload/books/166000/166640/157958-352x500.jpg", 49.990000000000002, "The Winds of Winter" },
                    { new Guid("01457142-358f-495f-aafa-fb23de3d67e9"), new Guid("578359b7-1967-41d6-8b87-64ab7605587e"), new Guid("8e6bc666-a459-4083-96ea-4654afe99d83"), new DateTime(2021, 11, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6543), "Good-natured and often humorous, Speechless is at times a 'song of curses', as Lanoye describes the conflicts with his beloved diva of a mother and her brave struggle with decline and death.", "http://cdn-lubimyczytac.pl/upload/books/4876000/4876555/715391-352x500.jpg", 49.990000000000002, "Speechless" },
                    { new Guid("1325360c-8253-473a-a20f-55c269c20407"), new Guid("a1da1d8e-1988-4634-b538-a01709477b77"), new Guid("8e6bc666-a459-4083-96ea-4654afe99d83"), new DateTime(2022, 1, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6555), "Easy Money or Snabba cash is a novel from 2006 by Jens Lapidus. It has been a success in term of sales, and the paperback was the fourth best seller of Swedish novels in 2007.", "https://cdn-lubimyczytac.pl/upload/books/27000/27802/352x500.jpg", 49.990000000000002, "Easy Money" },
                    { new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"), new Guid("a1da1d8e-1988-4634-b538-a01709477b77"), new Guid("28b53ff0-0547-40c6-884c-9646cc4c3906"), new DateTime(2021, 5, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6503), "It is a 1986 horror novel by American author Stephen King. The story follows the exploits of seven children as they are terrorized by the eponymous being, which exploits the fears and phobias of its victims in order to disguise itself while hunting its prey. 'It' primarily appears in the form of a clown in order to attract its preferred prey of young children.", "http://upload.wikimedia.org/wikipedia/en/thumb/5/5a/It_cover.jpg/220px-It_cover.jpg", 49.990000000000002, "It" },
                    { new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"), new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"), new Guid("28b53ff0-0547-40c6-884c-9646cc4c3906"), new DateTime(2021, 12, 8, 3, 39, 43, 681, DateTimeKind.Local).AddTicks(6549), "The Hitchhiker's Guide to the Galaxy is the first of five books in the Hitchhiker's Guide to the Galaxy comedy science fiction 'trilogy' by Douglas Adams.", "https://cdn-lubimyczytac.pl/upload/books/254000/254602/380738-352x500.jpg", 49.990000000000002, "The Hitchhiker's Guide to the Galaxy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
