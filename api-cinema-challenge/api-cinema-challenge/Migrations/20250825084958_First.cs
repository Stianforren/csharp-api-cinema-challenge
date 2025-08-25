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
                    phone = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    runtime_mins = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                columns: new[] { "customer_id", "CreatedAt", "email", "name", "phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(713), "kate middleton@gov.gr", "Kate Middleton", "57323012", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(932) },
                    { 2, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2183), "kate trump@something.com", "Kate Trump", "90036955", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2183) },
                    { 3, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2204), "kate winslet@gov.ru", "Kate Winslet", "79662272", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2208) },
                    { 4, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2211), "kate winslet@something.com", "Kate Winslet", "97434122", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2211) },
                    { 5, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2213), "elvis hendrix@gov.us", "Elvis Hendrix", "84320894", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2215) },
                    { 6, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2240), "kate hendrix@gov.ru", "Kate Hendrix", "86093045", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2241) },
                    { 7, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2242), "jimi trump@google.com", "Jimi Trump", "77608896", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2243) },
                    { 8, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2244), "kate hendrix@gov.nl", "Kate Hendrix", "30950692", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2245) },
                    { 9, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2246), "charles hepburn@google.com", "Charles Hepburn", "53960475", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2246) },
                    { 10, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2249), "barack obama@gov.nl", "Barack Obama", "11402717", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2249) },
                    { 11, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2252), "mick jagger@gov.gr", "Mick Jagger", "74377263", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2252) },
                    { 12, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2253), "kate hepburn@tesla.com", "Kate Hepburn", "37130689", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2254) },
                    { 13, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2255), "kate windsor@google.com", "Kate Windsor", "17850864", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2255) },
                    { 14, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2257), "donald jagger@tesla.com", "Donald Jagger", "96174535", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2257) },
                    { 15, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2259), "barack hendrix@something.com", "Barack Hendrix", "38010217", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2259) },
                    { 16, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2260), "elvis winfrey@gov.nl", "Elvis Winfrey", "68797228", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2260) },
                    { 17, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2262), "mick middleton@something.com", "Mick Middleton", "55871184", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2262) },
                    { 18, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2265), "elvis obama@nasa.org.us", "Elvis Obama", "99746360", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2266) },
                    { 19, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2267), "jimi hepburn@gov.gr", "Jimi Hepburn", "15774057", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2267) },
                    { 20, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2269), "kate presley@tesla.com", "Kate Presley", "33030025", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2269) },
                    { 21, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2270), "mick windsor@theworld.ca", "Mick Windsor", "68406720", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2270) },
                    { 22, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2272), "mick windsor@bbc.co.uk", "Mick Windsor", "70274513", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2272) },
                    { 23, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2273), "barack windsor@google.com", "Barack Windsor", "10112351", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2273) },
                    { 24, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2275), "elvis hendrix@bbc.co.uk", "Elvis Hendrix", "21340088", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2275) },
                    { 25, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2276), "barack hendrix@nasa.org.us", "Barack Hendrix", "67170625", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2276) },
                    { 26, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2278), "kate winslet@bbc.co.uk", "Kate Winslet", "86772435", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2278) },
                    { 27, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2279), "barack obama@bbc.co.uk", "Barack Obama", "83625317", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2279) },
                    { 28, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2281), "jimi hepburn@gov.nl", "Jimi Hepburn", "89412341", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2281) },
                    { 29, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2293), "mick jagger@gov.nl", "Mick Jagger", "37434825", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2294) },
                    { 30, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2295), "barack jagger@gov.ru", "Barack Jagger", "23194181", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2296) },
                    { 31, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2297), "elvis winfrey@gov.nl", "Elvis Winfrey", "54447837", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2297) },
                    { 32, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2299), "kate winfrey@bbc.co.uk", "Kate Winfrey", "58976369", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2299) },
                    { 33, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2300), "charles jagger@something.com", "Charles Jagger", "22440998", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2301) },
                    { 34, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2303), "kate middleton@nasa.org.us", "Kate Middleton", "19231484", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2303) },
                    { 35, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2304), "oprah jagger@nasa.org.us", "Oprah Jagger", "96209492", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2305) },
                    { 36, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2306), "jimi middleton@gov.us", "Jimi Middleton", "14860055", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2306) },
                    { 37, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2308), "mick windsor@bbc.co.uk", "Mick Windsor", "46462376", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2308) },
                    { 38, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2309), "elvis presley@theworld.ca", "Elvis Presley", "11443439", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2310) },
                    { 39, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2311), "donald winfrey@something.com", "Donald Winfrey", "71902615", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2311) },
                    { 40, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2313), "charles hepburn@gov.us", "Charles Hepburn", "42984697", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2313) },
                    { 41, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2314), "mick jagger@tesla.com", "Mick Jagger", "36431777", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2315) },
                    { 42, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2316), "jimi hepburn@gov.nl", "Jimi Hepburn", "93119392", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2316) },
                    { 43, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2318), "mick middleton@bbc.co.uk", "Mick Middleton", "60445327", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2318) },
                    { 44, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2319), "jimi winslet@tesla.com", "Jimi Winslet", "27412326", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2320) },
                    { 45, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2321), "audrey windsor@tesla.com", "Audrey Windsor", "41701761", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2321) },
                    { 46, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2322), "kate middleton@gov.nl", "Kate Middleton", "77306134", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2323) },
                    { 47, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2324), "mick hepburn@gov.gr", "Mick Hepburn", "69932733", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2325) },
                    { 48, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2326), "donald winslet@gov.us", "Donald Winslet", "95603319", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2326) },
                    { 49, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2327), "elvis trump@gov.ru", "Elvis Trump", "75749612", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2328) }
                });

            migrationBuilder.InsertData(
                table: "movie",
                columns: new[] { "movie_id", "CreatedAt", "description", "rating", "runtime_mins", "title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2700), "Very funny", "years 18+", 148, "The Bitter Flowers", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(2811) },
                    { 2, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3338), "Very funny", "years 16+", 93, "A bunch of Orange Flowers", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3339) },
                    { 3, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3343), "Very funny", "years 6+", 127, "Several Transparent Buildings", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3344) },
                    { 4, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3346), "Very funny", "All", 70, "A herd of Green Planets", new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3346) }
                });

            migrationBuilder.InsertData(
                table: "screenings",
                columns: new[] { "screening_id", "capacity", "CreatedAt", "movie_id", "screen_number", "starts_at", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 89, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3602), 3, 0, new DateTime(2025, 7, 19, 18, 15, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(3692) },
                    { 2, 89, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4667), 2, 0, new DateTime(2025, 8, 1, 11, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4668) },
                    { 3, 57, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4671), 2, 1, new DateTime(2025, 7, 3, 9, 55, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4671) },
                    { 4, 26, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4672), 4, 3, new DateTime(2025, 4, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4673) },
                    { 5, 61, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4674), 1, 0, new DateTime(2025, 5, 14, 16, 45, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4674) },
                    { 6, 54, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4676), 4, 4, new DateTime(2025, 1, 5, 8, 15, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4677) },
                    { 7, 76, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4686), 2, 3, new DateTime(2025, 3, 10, 6, 20, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4686) },
                    { 8, 84, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4687), 4, 1, new DateTime(2025, 6, 22, 13, 40, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4688) },
                    { 9, 83, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4689), 2, 4, new DateTime(2025, 2, 3, 7, 45, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4689) },
                    { 10, 68, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4690), 2, 2, new DateTime(2025, 6, 7, 4, 25, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4691) },
                    { 11, 74, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4691), 4, 0, new DateTime(2025, 3, 25, 15, 50, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4692) },
                    { 12, 45, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4693), 1, 1, new DateTime(2025, 3, 10, 6, 20, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4693) },
                    { 13, 34, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4694), 2, 2, new DateTime(2025, 3, 25, 15, 50, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4694) },
                    { 14, 25, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4695), 4, 0, new DateTime(2025, 6, 7, 4, 25, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4695) },
                    { 15, 67, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4696), 4, 3, new DateTime(2025, 4, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4696) },
                    { 16, 67, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4697), 4, 2, new DateTime(2025, 7, 3, 9, 55, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4697) },
                    { 17, 68, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4698), 4, 0, new DateTime(2025, 7, 19, 18, 15, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4698) },
                    { 18, 35, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4699), 1, 1, new DateTime(2025, 8, 1, 11, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4699) },
                    { 19, 72, new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4700), 4, 2, new DateTime(2025, 2, 21, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 8, 49, 55, 411, DateTimeKind.Utc).AddTicks(4700) }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "ticket_id", "customer_id", "screening_id" },
                values: new object[,]
                {
                    { 1, 28, 5 },
                    { 2, 32, 2 },
                    { 3, 21, 5 },
                    { 4, 10, 17 },
                    { 5, 19, 3 },
                    { 6, 34, 2 },
                    { 7, 25, 2 },
                    { 8, 40, 6 },
                    { 9, 18, 17 },
                    { 10, 2, 4 },
                    { 11, 41, 10 },
                    { 12, 17, 11 },
                    { 13, 11, 10 },
                    { 14, 37, 16 },
                    { 15, 27, 4 },
                    { 16, 36, 16 },
                    { 17, 31, 2 },
                    { 18, 1, 3 },
                    { 19, 22, 14 },
                    { 20, 40, 17 },
                    { 21, 49, 2 },
                    { 22, 11, 3 },
                    { 23, 38, 17 },
                    { 24, 12, 5 },
                    { 25, 3, 16 },
                    { 26, 11, 4 },
                    { 27, 19, 7 },
                    { 28, 3, 13 },
                    { 29, 41, 12 },
                    { 30, 42, 8 },
                    { 31, 28, 16 },
                    { 32, 48, 15 },
                    { 33, 45, 6 },
                    { 34, 28, 4 },
                    { 35, 44, 2 },
                    { 36, 37, 9 },
                    { 37, 30, 4 },
                    { 38, 20, 14 },
                    { 39, 39, 1 },
                    { 40, 14, 2 },
                    { 41, 2, 9 },
                    { 42, 28, 7 },
                    { 43, 25, 9 },
                    { 44, 42, 11 },
                    { 45, 1, 2 },
                    { 46, 1, 14 },
                    { 47, 1, 13 },
                    { 48, 38, 13 },
                    { 49, 6, 7 },
                    { 50, 1, 15 },
                    { 51, 37, 7 },
                    { 52, 33, 9 },
                    { 53, 3, 5 },
                    { 54, 40, 5 },
                    { 55, 9, 15 },
                    { 56, 49, 18 },
                    { 57, 29, 17 },
                    { 58, 4, 1 },
                    { 59, 40, 19 },
                    { 60, 47, 15 },
                    { 61, 22, 6 },
                    { 62, 34, 12 },
                    { 63, 28, 14 },
                    { 64, 45, 8 },
                    { 65, 4, 7 },
                    { 66, 47, 12 },
                    { 67, 22, 19 },
                    { 68, 6, 12 },
                    { 69, 47, 4 },
                    { 70, 17, 14 },
                    { 71, 40, 17 },
                    { 72, 21, 5 },
                    { 73, 4, 13 },
                    { 74, 4, 12 },
                    { 75, 41, 14 },
                    { 76, 19, 19 },
                    { 77, 20, 6 },
                    { 78, 9, 16 },
                    { 79, 14, 4 },
                    { 80, 44, 17 },
                    { 81, 26, 17 },
                    { 82, 37, 1 },
                    { 83, 41, 4 },
                    { 84, 8, 19 },
                    { 85, 46, 16 },
                    { 86, 38, 18 },
                    { 87, 43, 19 },
                    { 88, 30, 14 },
                    { 89, 36, 5 },
                    { 90, 6, 9 },
                    { 91, 17, 18 },
                    { 92, 40, 6 },
                    { 93, 25, 8 },
                    { 94, 28, 5 },
                    { 95, 19, 15 },
                    { 96, 33, 13 },
                    { 97, 5, 19 },
                    { 98, 36, 7 },
                    { 99, 18, 15 },
                    { 100, 43, 1 },
                    { 101, 19, 2 },
                    { 102, 47, 16 },
                    { 103, 24, 10 },
                    { 104, 29, 19 },
                    { 105, 23, 18 },
                    { 106, 49, 18 },
                    { 107, 26, 13 },
                    { 108, 17, 14 },
                    { 109, 46, 6 },
                    { 110, 46, 15 },
                    { 111, 47, 15 },
                    { 112, 31, 3 },
                    { 113, 48, 2 },
                    { 114, 31, 4 },
                    { 115, 21, 8 },
                    { 116, 36, 2 },
                    { 117, 8, 4 },
                    { 118, 12, 19 },
                    { 119, 42, 9 },
                    { 120, 13, 4 },
                    { 121, 16, 12 },
                    { 122, 30, 15 },
                    { 123, 13, 17 },
                    { 124, 28, 7 },
                    { 125, 8, 8 },
                    { 126, 8, 9 },
                    { 127, 38, 14 },
                    { 128, 21, 10 },
                    { 129, 34, 9 },
                    { 130, 13, 18 },
                    { 131, 34, 16 },
                    { 132, 29, 18 },
                    { 133, 5, 16 },
                    { 134, 4, 3 },
                    { 135, 30, 9 },
                    { 136, 48, 4 },
                    { 137, 49, 1 },
                    { 138, 38, 15 },
                    { 139, 29, 6 },
                    { 140, 5, 15 },
                    { 141, 12, 8 },
                    { 142, 2, 13 },
                    { 143, 7, 2 },
                    { 144, 9, 16 },
                    { 145, 26, 13 },
                    { 146, 14, 11 },
                    { 147, 49, 3 },
                    { 148, 17, 7 },
                    { 149, 3, 18 },
                    { 150, 17, 14 },
                    { 151, 19, 2 },
                    { 152, 8, 7 },
                    { 153, 8, 12 },
                    { 154, 16, 15 },
                    { 155, 23, 12 },
                    { 156, 2, 4 },
                    { 157, 34, 7 },
                    { 158, 18, 16 },
                    { 159, 9, 12 },
                    { 160, 37, 18 },
                    { 161, 27, 17 },
                    { 162, 26, 3 },
                    { 163, 34, 11 },
                    { 164, 4, 4 },
                    { 165, 26, 10 },
                    { 166, 2, 6 },
                    { 167, 2, 9 },
                    { 168, 20, 5 },
                    { 169, 18, 12 },
                    { 170, 49, 11 },
                    { 171, 24, 11 },
                    { 172, 11, 11 },
                    { 173, 20, 2 },
                    { 174, 6, 11 },
                    { 175, 47, 13 },
                    { 176, 18, 9 },
                    { 177, 1, 14 },
                    { 178, 29, 9 },
                    { 179, 21, 11 },
                    { 180, 14, 2 },
                    { 181, 22, 6 },
                    { 182, 33, 10 },
                    { 183, 34, 6 },
                    { 184, 35, 8 },
                    { 185, 27, 12 },
                    { 186, 34, 2 },
                    { 187, 31, 3 },
                    { 188, 39, 5 },
                    { 189, 22, 3 },
                    { 190, 3, 4 },
                    { 191, 42, 12 },
                    { 192, 47, 18 },
                    { 193, 5, 18 },
                    { 194, 3, 15 },
                    { 195, 26, 19 },
                    { 196, 44, 8 },
                    { 197, 29, 18 },
                    { 198, 30, 7 },
                    { 199, 2, 8 }
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
