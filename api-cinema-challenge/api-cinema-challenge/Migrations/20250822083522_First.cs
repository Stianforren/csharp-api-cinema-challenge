using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_cinema_challenge.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    runtime_mins = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.movie_id);
                });

            migrationBuilder.CreateTable(
                name: "screenings",
                columns: table => new
                {
                    screening_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    screen_number = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    starts_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    movie_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_screenings", x => x.screening_id);
                    table.ForeignKey(
                        name: "FK_screenings_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    ticket_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    screening_id = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.ticket_id);
                    table.ForeignKey(
                        name: "FK_tickets_Customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_screenings_screening_id",
                        column: x => x.screening_id,
                        principalTable: "screenings",
                        principalColumn: "screening_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "email", "name", "phone" },
                values: new object[,]
                {
                    { 1, "mick winfrey@gov.gr", "Mick Winfrey", "52368274" },
                    { 2, "charles winfrey@gov.nl", "Charles Winfrey", "79181350" },
                    { 3, "jimi hendrix@bbc.co.uk", "Jimi Hendrix", "72502892" },
                    { 4, "jimi hepburn@gov.ru", "Jimi Hepburn", "15545519" },
                    { 5, "audrey hepburn@theworld.ca", "Audrey Hepburn", "92238414" },
                    { 6, "kate trump@bbc.co.uk", "Kate Trump", "86190574" },
                    { 7, "kate obama@google.com", "Kate Obama", "18975724" },
                    { 8, "jimi winslet@gov.nl", "Jimi Winslet", "92579632" },
                    { 9, "mick hepburn@gov.ru", "Mick Hepburn", "67334813" },
                    { 10, "kate hendrix@tesla.com", "Kate Hendrix", "82550950" },
                    { 11, "oprah presley@gov.gr", "Oprah Presley", "52997360" },
                    { 12, "elvis hepburn@google.com", "Elvis Hepburn", "64207390" },
                    { 13, "oprah jagger@gov.gr", "Oprah Jagger", "91111243" },
                    { 14, "elvis hendrix@gov.us", "Elvis Hendrix", "13823444" },
                    { 15, "kate hepburn@gov.ru", "Kate Hepburn", "97284220" },
                    { 16, "mick jagger@bbc.co.uk", "Mick Jagger", "28858754" },
                    { 17, "elvis winfrey@gov.ru", "Elvis Winfrey", "30038727" },
                    { 18, "barack presley@tesla.com", "Barack Presley", "99825705" },
                    { 19, "kate hepburn@gov.nl", "Kate Hepburn", "74139655" },
                    { 20, "mick jagger@gov.us", "Mick Jagger", "95805889" },
                    { 21, "mick presley@something.com", "Mick Presley", "48857519" },
                    { 22, "charles jagger@gov.nl", "Charles Jagger", "17920562" },
                    { 23, "barack trump@tesla.com", "Barack Trump", "26069406" },
                    { 24, "kate winslet@gov.nl", "Kate Winslet", "69787774" },
                    { 25, "jimi obama@bbc.co.uk", "Jimi Obama", "29989532" },
                    { 26, "elvis obama@gov.nl", "Elvis Obama", "44895432" },
                    { 27, "oprah hepburn@gov.nl", "Oprah Hepburn", "89556044" },
                    { 28, "elvis windsor@gov.gr", "Elvis Windsor", "60390346" },
                    { 29, "charles windsor@theworld.ca", "Charles Windsor", "44104543" },
                    { 30, "donald hendrix@gov.ru", "Donald Hendrix", "25105264" },
                    { 31, "elvis obama@something.com", "Elvis Obama", "52810651" },
                    { 32, "barack winfrey@google.com", "Barack Winfrey", "34881251" },
                    { 33, "mick obama@tesla.com", "Mick Obama", "36227999" },
                    { 34, "oprah hepburn@tesla.com", "Oprah Hepburn", "73319625" },
                    { 35, "kate windsor@something.com", "Kate Windsor", "61318402" },
                    { 36, "audrey presley@tesla.com", "Audrey Presley", "39504124" },
                    { 37, "kate presley@google.com", "Kate Presley", "16265734" },
                    { 38, "donald hendrix@google.com", "Donald Hendrix", "35991180" },
                    { 39, "mick hepburn@bbc.co.uk", "Mick Hepburn", "49117273" },
                    { 40, "oprah winfrey@gov.ru", "Oprah Winfrey", "72634505" },
                    { 41, "jimi trump@gov.us", "Jimi Trump", "96850307" },
                    { 42, "jimi winslet@gov.gr", "Jimi Winslet", "27324349" },
                    { 43, "audrey jagger@tesla.com", "Audrey Jagger", "91669517" },
                    { 44, "audrey obama@nasa.org.us", "Audrey Obama", "51414027" },
                    { 45, "kate jagger@gov.us", "Kate Jagger", "52606573" },
                    { 46, "audrey obama@something.com", "Audrey Obama", "41214230" },
                    { 47, "kate obama@gov.us", "Kate Obama", "11348879" },
                    { 48, "audrey presley@something.com", "Audrey Presley", "87270053" },
                    { 49, "kate hendrix@tesla.com", "Kate Hendrix", "36685672" }
                });

            migrationBuilder.InsertData(
                table: "movie",
                columns: new[] { "movie_id", "description", "rating", "runtime_mins", "title" },
                values: new object[,]
                {
                    { 1, "Very funny", "years 16+", 146, "The Transparent Flowers" },
                    { 2, "Very funny", "years 6+", 117, "Two Microscopic Houses" },
                    { 3, "Very funny", "years 11+", 129, "A herd of Orange Leopards" },
                    { 4, "Very funny", "years 16+", 80, "Several Microscopic Houses" }
                });

            migrationBuilder.InsertData(
                table: "screenings",
                columns: new[] { "screening_id", "capacity", "movie_id", "screen_number", "starts_at" },
                values: new object[,]
                {
                    { 1, 67, 2, 4, new DateTime(2025, 6, 22, 13, 40, 0, 0, DateTimeKind.Utc) },
                    { 2, 46, 3, 4, new DateTime(2025, 1, 5, 8, 15, 0, 0, DateTimeKind.Utc) },
                    { 3, 27, 2, 1, new DateTime(2025, 8, 1, 11, 30, 0, 0, DateTimeKind.Utc) },
                    { 4, 98, 3, 0, new DateTime(2025, 7, 19, 18, 15, 0, 0, DateTimeKind.Utc) },
                    { 5, 43, 3, 3, new DateTime(2025, 4, 18, 19, 30, 0, 0, DateTimeKind.Utc) },
                    { 6, 31, 1, 4, new DateTime(2025, 7, 3, 9, 55, 0, 0, DateTimeKind.Utc) },
                    { 7, 66, 1, 4, new DateTime(2025, 3, 25, 15, 50, 0, 0, DateTimeKind.Utc) },
                    { 8, 63, 1, 2, new DateTime(2025, 7, 3, 9, 55, 0, 0, DateTimeKind.Utc) },
                    { 9, 47, 3, 2, new DateTime(2025, 4, 2, 10, 5, 0, 0, DateTimeKind.Utc) },
                    { 10, 36, 2, 4, new DateTime(2025, 2, 3, 7, 45, 0, 0, DateTimeKind.Utc) },
                    { 11, 81, 1, 4, new DateTime(2025, 3, 10, 6, 20, 0, 0, DateTimeKind.Utc) },
                    { 12, 28, 1, 3, new DateTime(2025, 2, 3, 7, 45, 0, 0, DateTimeKind.Utc) },
                    { 13, 80, 1, 4, new DateTime(2025, 1, 5, 8, 15, 0, 0, DateTimeKind.Utc) },
                    { 14, 57, 1, 4, new DateTime(2025, 2, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 33, 3, 2, new DateTime(2025, 4, 2, 10, 5, 0, 0, DateTimeKind.Utc) },
                    { 16, 94, 1, 2, new DateTime(2025, 2, 3, 7, 45, 0, 0, DateTimeKind.Utc) },
                    { 17, 28, 2, 2, new DateTime(2025, 4, 2, 10, 5, 0, 0, DateTimeKind.Utc) },
                    { 18, 52, 3, 3, new DateTime(2025, 8, 1, 11, 30, 0, 0, DateTimeKind.Utc) },
                    { 19, 75, 1, 2, new DateTime(2025, 2, 21, 18, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "ticket_id", "customer_id", "screening_id" },
                values: new object[,]
                {
                    { 1, 43, 14 },
                    { 2, 1, 5 },
                    { 3, 40, 9 },
                    { 4, 10, 9 },
                    { 5, 26, 5 },
                    { 6, 26, 9 },
                    { 7, 45, 5 },
                    { 8, 47, 9 },
                    { 9, 10, 11 },
                    { 10, 31, 15 },
                    { 11, 43, 8 },
                    { 12, 2, 3 },
                    { 13, 18, 14 },
                    { 14, 15, 15 },
                    { 15, 29, 16 },
                    { 16, 46, 8 },
                    { 17, 30, 2 },
                    { 18, 3, 19 },
                    { 19, 48, 7 },
                    { 20, 41, 9 },
                    { 21, 3, 14 },
                    { 22, 16, 5 },
                    { 23, 14, 4 },
                    { 24, 39, 4 },
                    { 25, 7, 19 },
                    { 26, 32, 14 },
                    { 27, 35, 7 },
                    { 28, 22, 12 },
                    { 29, 21, 7 },
                    { 30, 2, 18 },
                    { 31, 44, 4 },
                    { 32, 42, 12 },
                    { 33, 48, 2 },
                    { 34, 5, 12 },
                    { 35, 37, 16 },
                    { 36, 37, 10 },
                    { 37, 5, 18 },
                    { 38, 9, 14 },
                    { 39, 10, 3 },
                    { 40, 21, 16 },
                    { 41, 5, 17 },
                    { 42, 11, 15 },
                    { 43, 49, 7 },
                    { 44, 30, 5 },
                    { 45, 45, 18 },
                    { 46, 18, 19 },
                    { 47, 27, 5 },
                    { 48, 38, 7 },
                    { 49, 1, 16 },
                    { 50, 34, 5 },
                    { 51, 4, 2 },
                    { 52, 33, 11 },
                    { 53, 7, 19 },
                    { 54, 14, 12 },
                    { 55, 49, 5 },
                    { 56, 8, 11 },
                    { 57, 43, 4 },
                    { 58, 32, 6 },
                    { 59, 40, 2 },
                    { 60, 38, 12 },
                    { 61, 29, 3 },
                    { 62, 24, 4 },
                    { 63, 11, 4 },
                    { 64, 6, 13 },
                    { 65, 4, 13 },
                    { 66, 42, 8 },
                    { 67, 48, 16 },
                    { 68, 15, 12 },
                    { 69, 18, 13 },
                    { 70, 9, 19 },
                    { 71, 47, 6 },
                    { 72, 36, 4 },
                    { 73, 46, 6 },
                    { 74, 27, 19 },
                    { 75, 21, 19 },
                    { 76, 13, 9 },
                    { 77, 9, 13 },
                    { 78, 1, 12 },
                    { 79, 5, 15 },
                    { 80, 35, 14 },
                    { 81, 43, 14 },
                    { 82, 1, 10 },
                    { 83, 26, 18 },
                    { 84, 47, 2 },
                    { 85, 3, 4 },
                    { 86, 35, 2 },
                    { 87, 6, 19 },
                    { 88, 7, 14 },
                    { 89, 12, 15 },
                    { 90, 12, 19 },
                    { 91, 7, 17 },
                    { 92, 8, 14 },
                    { 93, 19, 2 },
                    { 94, 22, 18 },
                    { 95, 2, 16 },
                    { 96, 2, 4 },
                    { 97, 13, 8 },
                    { 98, 4, 9 },
                    { 99, 12, 11 },
                    { 100, 5, 6 },
                    { 101, 16, 16 },
                    { 102, 5, 14 },
                    { 103, 45, 8 },
                    { 104, 23, 15 },
                    { 105, 15, 18 },
                    { 106, 43, 4 },
                    { 107, 45, 14 },
                    { 108, 28, 12 },
                    { 109, 31, 17 },
                    { 110, 32, 18 },
                    { 111, 36, 18 },
                    { 112, 41, 16 },
                    { 113, 22, 14 },
                    { 114, 26, 18 },
                    { 115, 29, 1 },
                    { 116, 19, 18 },
                    { 117, 18, 11 },
                    { 118, 16, 19 },
                    { 119, 7, 5 },
                    { 120, 1, 7 },
                    { 121, 36, 2 },
                    { 122, 39, 12 },
                    { 123, 13, 18 },
                    { 124, 13, 12 },
                    { 125, 25, 13 },
                    { 126, 31, 14 },
                    { 127, 18, 9 },
                    { 128, 42, 3 },
                    { 129, 9, 14 },
                    { 130, 44, 4 },
                    { 131, 6, 18 },
                    { 132, 18, 5 },
                    { 133, 39, 5 },
                    { 134, 13, 15 },
                    { 135, 36, 17 },
                    { 136, 15, 1 },
                    { 137, 35, 6 },
                    { 138, 28, 2 },
                    { 139, 16, 18 },
                    { 140, 39, 11 },
                    { 141, 7, 8 },
                    { 142, 38, 7 },
                    { 143, 2, 16 },
                    { 144, 24, 6 },
                    { 145, 42, 13 },
                    { 146, 6, 8 },
                    { 147, 26, 14 },
                    { 148, 40, 13 },
                    { 149, 16, 7 },
                    { 150, 21, 14 },
                    { 151, 6, 14 },
                    { 152, 11, 1 },
                    { 153, 19, 4 },
                    { 154, 20, 6 },
                    { 155, 34, 10 },
                    { 156, 41, 2 },
                    { 157, 42, 19 },
                    { 158, 27, 17 },
                    { 159, 46, 1 },
                    { 160, 5, 13 },
                    { 161, 2, 15 },
                    { 162, 39, 17 },
                    { 163, 20, 7 },
                    { 164, 5, 8 },
                    { 165, 1, 6 },
                    { 166, 14, 12 },
                    { 167, 35, 10 },
                    { 168, 32, 3 },
                    { 169, 6, 15 },
                    { 170, 24, 8 },
                    { 171, 10, 8 },
                    { 172, 5, 16 },
                    { 173, 19, 5 },
                    { 174, 27, 8 },
                    { 175, 39, 1 },
                    { 176, 49, 7 },
                    { 177, 34, 10 },
                    { 178, 38, 14 },
                    { 179, 47, 11 },
                    { 180, 22, 14 },
                    { 181, 32, 15 },
                    { 182, 23, 19 },
                    { 183, 3, 18 },
                    { 184, 8, 9 },
                    { 185, 1, 9 },
                    { 186, 16, 19 },
                    { 187, 3, 11 },
                    { 188, 28, 3 },
                    { 189, 34, 13 },
                    { 190, 1, 6 },
                    { 191, 26, 8 },
                    { 192, 14, 5 },
                    { 193, 37, 11 },
                    { 194, 13, 11 },
                    { 195, 46, 4 },
                    { 196, 49, 12 },
                    { 197, 45, 7 },
                    { 198, 25, 9 },
                    { 199, 6, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_screenings_movie_id",
                table: "screenings",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_customer_id",
                table: "tickets",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_screening_id",
                table: "tickets",
                column: "screening_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "screenings");

            migrationBuilder.DropTable(
                name: "movie");
        }
    }
}
