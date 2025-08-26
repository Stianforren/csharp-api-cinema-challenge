using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_cinema_challenge.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

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
                    { 1, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(2035), "audrey hepburn@gov.gr", "Audrey Hepburn", "24634684", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(2268) },
                    { 2, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3539), "kate hepburn@bbc.co.uk", "Kate Hepburn", "49646097", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3540) },
                    { 3, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3563), "charles presley@gov.nl", "Charles Presley", "26639659", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3563) },
                    { 4, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3565), "donald hendrix@gov.ru", "Donald Hendrix", "65109755", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3566) },
                    { 5, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3568), "oprah middleton@gov.us", "Oprah Middleton", "43044406", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3568) },
                    { 6, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3579), "kate trump@bbc.co.uk", "Kate Trump", "52083056", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3579) },
                    { 7, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3581), "charles winfrey@google.com", "Charles Winfrey", "85242581", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3581) },
                    { 8, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3604), "donald windsor@gov.us", "Donald Windsor", "57665393", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3605) },
                    { 9, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3606), "kate obama@google.com", "Kate Obama", "22385849", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3607) },
                    { 10, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3609), "donald windsor@something.com", "Donald Windsor", "62639816", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3609) },
                    { 11, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3611), "charles hepburn@gov.ru", "Charles Hepburn", "62276921", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3611) },
                    { 12, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3613), "elvis winfrey@tesla.com", "Elvis Winfrey", "35293476", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3613) },
                    { 13, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3614), "elvis hepburn@gov.us", "Elvis Hepburn", "84876191", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3615) },
                    { 14, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3616), "charles jagger@gov.ru", "Charles Jagger", "54864917", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3616) },
                    { 15, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3618), "barack winfrey@gov.ru", "Barack Winfrey", "34106523", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3618) },
                    { 16, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3619), "mick windsor@gov.gr", "Mick Windsor", "52226638", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3619) },
                    { 17, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3621), "elvis hepburn@nasa.org.us", "Elvis Hepburn", "50058133", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3621) },
                    { 18, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3623), "jimi jagger@gov.us", "Jimi Jagger", "30126005", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3623) },
                    { 19, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3624), "kate jagger@nasa.org.us", "Kate Jagger", "28409903", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3625) },
                    { 20, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3626), "kate jagger@something.com", "Kate Jagger", "27803251", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3626) },
                    { 21, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3627), "barack winslet@bbc.co.uk", "Barack Winslet", "56314127", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3628) },
                    { 22, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3629), "jimi presley@tesla.com", "Jimi Presley", "51246437", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3629) },
                    { 23, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3630), "kate winslet@something.com", "Kate Winslet", "12062719", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3631) },
                    { 24, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3632), "mick presley@gov.ru", "Mick Presley", "84330792", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3633) },
                    { 25, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3634), "kate hepburn@tesla.com", "Kate Hepburn", "60705909", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3634) },
                    { 26, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3635), "kate winslet@nasa.org.us", "Kate Winslet", "47374763", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3636) },
                    { 27, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3637), "audrey presley@gov.us", "Audrey Presley", "89646824", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3637) },
                    { 28, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3638), "jimi hepburn@gov.gr", "Jimi Hepburn", "70843563", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3639) },
                    { 29, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3640), "mick windsor@nasa.org.us", "Mick Windsor", "21891104", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3640) },
                    { 30, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3641), "donald trump@nasa.org.us", "Donald Trump", "77180744", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3642) },
                    { 31, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3648), "kate presley@gov.nl", "Kate Presley", "18549554", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3649) },
                    { 32, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3651), "kate winslet@tesla.com", "Kate Winslet", "22886454", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3651) },
                    { 33, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3652), "elvis winfrey@something.com", "Elvis Winfrey", "44923720", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3653) },
                    { 34, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3655), "kate winfrey@gov.nl", "Kate Winfrey", "52713833", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3655) },
                    { 35, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3656), "jimi hendrix@gov.nl", "Jimi Hendrix", "69254646", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3656) },
                    { 36, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3658), "barack trump@tesla.com", "Barack Trump", "18571321", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3658) },
                    { 37, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3659), "elvis middleton@bbc.co.uk", "Elvis Middleton", "66441056", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3659) },
                    { 38, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3661), "jimi middleton@bbc.co.uk", "Jimi Middleton", "31023577", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3661) },
                    { 39, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3663), "kate hendrix@gov.ru", "Kate Hendrix", "22668985", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3663) },
                    { 40, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3664), "kate hepburn@theworld.ca", "Kate Hepburn", "54717904", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3664) },
                    { 41, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3666), "elvis jagger@tesla.com", "Elvis Jagger", "72683693", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3666) },
                    { 42, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3667), "barack middleton@nasa.org.us", "Barack Middleton", "23610983", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3667) },
                    { 43, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3669), "kate obama@bbc.co.uk", "Kate Obama", "28499438", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3669) },
                    { 44, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3670), "elvis middleton@gov.ru", "Elvis Middleton", "39411817", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3671) },
                    { 45, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3672), "jimi jagger@gov.us", "Jimi Jagger", "54613053", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3672) },
                    { 46, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3674), "oprah presley@bbc.co.uk", "Oprah Presley", "80862726", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3674) },
                    { 47, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3675), "jimi obama@nasa.org.us", "Jimi Obama", "20418161", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3675) },
                    { 48, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3677), "charles hepburn@theworld.ca", "Charles Hepburn", "17586489", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3677) },
                    { 49, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3678), "oprah middleton@google.com", "Oprah Middleton", "48095329", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(3678) }
                });

            migrationBuilder.InsertData(
                table: "movie",
                columns: new[] { "movie_id", "CreatedAt", "description", "rating", "runtime_mins", "title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4071), "Very funny", "years 11+", 129, "A bunch of Large Flowers", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4202) },
                    { 2, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4757), "Very funny", "All", 118, "Several Green Flowers", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4758) },
                    { 3, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4762), "Very funny", "years 16+", 123, "Several Purple Buildings", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4762) },
                    { 4, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4764), "Very funny", "years 6+", 72, "The Bitter Houses", new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(4765) }
                });

            migrationBuilder.InsertData(
                table: "screenings",
                columns: new[] { "screening_id", "capacity", "CreatedAt", "movie_id", "screen_number", "starts_at", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 77, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(5046), 1, 0, new DateTime(2025, 1, 12, 13, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(5157) },
                    { 2, 25, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6485), 3, 3, new DateTime(2025, 1, 5, 8, 15, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6487) },
                    { 3, 27, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6490), 4, 2, new DateTime(2025, 5, 1, 8, 10, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6490) },
                    { 4, 84, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6491), 4, 2, new DateTime(2025, 6, 7, 4, 25, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6491) },
                    { 5, 63, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6492), 2, 3, new DateTime(2025, 2, 3, 7, 45, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6492) },
                    { 6, 25, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6503), 2, 1, new DateTime(2025, 5, 1, 8, 10, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6503) },
                    { 7, 65, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6504), 4, 0, new DateTime(2025, 6, 7, 4, 25, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6504) },
                    { 8, 48, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6505), 3, 0, new DateTime(2025, 2, 21, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6505) },
                    { 9, 77, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6506), 2, 4, new DateTime(2025, 6, 7, 4, 25, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6506) },
                    { 10, 59, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6508), 3, 4, new DateTime(2025, 2, 21, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6508) },
                    { 11, 87, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6508), 3, 0, new DateTime(2025, 1, 5, 8, 15, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6509) },
                    { 12, 99, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6509), 2, 3, new DateTime(2025, 1, 12, 13, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6510) },
                    { 13, 45, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6510), 2, 2, new DateTime(2025, 2, 3, 7, 45, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6510) },
                    { 14, 38, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6511), 2, 1, new DateTime(2025, 8, 1, 11, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6511) },
                    { 15, 26, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6512), 2, 0, new DateTime(2025, 6, 22, 13, 40, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6512) },
                    { 16, 51, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6512), 2, 4, new DateTime(2025, 4, 2, 10, 5, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6513) },
                    { 17, 74, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6513), 3, 3, new DateTime(2025, 6, 22, 13, 40, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6514) },
                    { 18, 79, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6515), 2, 0, new DateTime(2025, 1, 12, 13, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6515) },
                    { 19, 40, new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6516), 2, 2, new DateTime(2025, 1, 12, 13, 30, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 25, 13, 15, 2, 535, DateTimeKind.Utc).AddTicks(6516) }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "ticket_id", "customer_id", "screening_id" },
                values: new object[,]
                {
                    { 1, 33, 14 },
                    { 2, 28, 12 },
                    { 3, 17, 15 },
                    { 4, 2, 6 },
                    { 5, 41, 6 },
                    { 6, 42, 6 },
                    { 7, 27, 13 },
                    { 8, 39, 11 },
                    { 9, 17, 5 },
                    { 10, 25, 9 },
                    { 11, 9, 5 },
                    { 12, 30, 9 },
                    { 13, 36, 6 },
                    { 14, 41, 8 },
                    { 15, 6, 9 },
                    { 16, 30, 15 },
                    { 17, 46, 16 },
                    { 18, 21, 8 },
                    { 19, 6, 3 },
                    { 20, 47, 5 },
                    { 21, 40, 7 },
                    { 22, 28, 1 },
                    { 23, 32, 4 },
                    { 24, 23, 12 },
                    { 25, 12, 7 },
                    { 26, 17, 11 },
                    { 27, 18, 3 },
                    { 28, 34, 18 },
                    { 29, 49, 5 },
                    { 30, 7, 13 },
                    { 31, 42, 18 },
                    { 32, 14, 10 },
                    { 33, 26, 18 },
                    { 34, 33, 17 },
                    { 35, 21, 5 },
                    { 36, 44, 12 },
                    { 37, 28, 1 },
                    { 38, 1, 12 },
                    { 39, 14, 4 },
                    { 40, 1, 14 },
                    { 41, 44, 17 },
                    { 42, 29, 6 },
                    { 43, 45, 17 },
                    { 44, 37, 7 },
                    { 45, 35, 19 },
                    { 46, 12, 16 },
                    { 47, 44, 17 },
                    { 48, 42, 7 },
                    { 49, 28, 5 },
                    { 50, 43, 8 },
                    { 51, 26, 8 },
                    { 52, 44, 9 },
                    { 53, 4, 19 },
                    { 54, 22, 10 },
                    { 55, 15, 3 },
                    { 56, 43, 5 },
                    { 57, 43, 18 },
                    { 58, 9, 4 },
                    { 59, 15, 6 },
                    { 60, 22, 14 },
                    { 61, 3, 7 },
                    { 62, 43, 16 },
                    { 63, 7, 4 },
                    { 64, 27, 10 },
                    { 65, 13, 17 },
                    { 66, 39, 4 },
                    { 67, 47, 4 },
                    { 68, 21, 2 },
                    { 69, 46, 17 },
                    { 70, 14, 1 },
                    { 71, 28, 4 },
                    { 72, 47, 6 },
                    { 73, 5, 17 },
                    { 74, 11, 15 },
                    { 75, 46, 5 },
                    { 76, 45, 17 },
                    { 77, 6, 1 },
                    { 78, 16, 18 },
                    { 79, 36, 1 },
                    { 80, 43, 14 },
                    { 81, 12, 15 },
                    { 82, 40, 2 },
                    { 83, 5, 4 },
                    { 84, 36, 10 },
                    { 85, 21, 13 },
                    { 86, 4, 10 },
                    { 87, 42, 2 },
                    { 88, 1, 10 },
                    { 89, 5, 1 },
                    { 90, 34, 12 },
                    { 91, 35, 7 },
                    { 92, 47, 8 },
                    { 93, 35, 9 },
                    { 94, 5, 12 },
                    { 95, 43, 7 },
                    { 96, 36, 1 },
                    { 97, 4, 7 },
                    { 98, 31, 14 },
                    { 99, 25, 19 },
                    { 100, 49, 9 },
                    { 101, 4, 15 },
                    { 102, 34, 10 },
                    { 103, 14, 8 },
                    { 104, 28, 7 },
                    { 105, 38, 2 },
                    { 106, 7, 18 },
                    { 107, 40, 9 },
                    { 108, 22, 3 },
                    { 109, 4, 7 },
                    { 110, 34, 17 },
                    { 111, 6, 6 },
                    { 112, 9, 10 },
                    { 113, 39, 8 },
                    { 114, 22, 5 },
                    { 115, 26, 12 },
                    { 116, 34, 5 },
                    { 117, 15, 7 },
                    { 118, 41, 18 },
                    { 119, 39, 9 },
                    { 120, 14, 5 },
                    { 121, 10, 10 },
                    { 122, 3, 14 },
                    { 123, 16, 10 },
                    { 124, 3, 13 },
                    { 125, 43, 5 },
                    { 126, 39, 16 },
                    { 127, 6, 15 },
                    { 128, 20, 3 },
                    { 129, 29, 12 },
                    { 130, 31, 15 },
                    { 131, 10, 6 },
                    { 132, 16, 3 },
                    { 133, 13, 15 },
                    { 134, 17, 2 },
                    { 135, 18, 15 },
                    { 136, 41, 19 },
                    { 137, 41, 13 },
                    { 138, 23, 3 },
                    { 139, 40, 5 },
                    { 140, 38, 1 },
                    { 141, 7, 9 },
                    { 142, 45, 6 },
                    { 143, 30, 5 },
                    { 144, 14, 9 },
                    { 145, 14, 18 },
                    { 146, 23, 16 },
                    { 147, 31, 16 },
                    { 148, 45, 1 },
                    { 149, 3, 6 },
                    { 150, 1, 7 },
                    { 151, 35, 3 },
                    { 152, 1, 15 },
                    { 153, 4, 8 },
                    { 154, 25, 1 },
                    { 155, 32, 18 },
                    { 156, 34, 13 },
                    { 157, 33, 4 },
                    { 158, 24, 5 },
                    { 159, 31, 15 },
                    { 160, 44, 15 },
                    { 161, 37, 8 },
                    { 162, 3, 7 },
                    { 163, 27, 9 },
                    { 164, 40, 9 },
                    { 165, 16, 10 },
                    { 166, 26, 16 },
                    { 167, 31, 15 },
                    { 168, 18, 11 },
                    { 169, 30, 16 },
                    { 170, 48, 11 },
                    { 171, 30, 1 },
                    { 172, 17, 9 },
                    { 173, 24, 2 },
                    { 174, 3, 2 },
                    { 175, 32, 18 },
                    { 176, 33, 10 },
                    { 177, 48, 1 },
                    { 178, 36, 14 },
                    { 179, 47, 2 },
                    { 180, 43, 7 },
                    { 181, 13, 1 },
                    { 182, 19, 12 },
                    { 183, 35, 2 },
                    { 184, 37, 18 },
                    { 185, 28, 2 },
                    { 186, 11, 8 },
                    { 187, 43, 18 },
                    { 188, 36, 9 },
                    { 189, 25, 19 },
                    { 190, 40, 16 },
                    { 191, 8, 17 },
                    { 192, 23, 17 },
                    { 193, 49, 7 },
                    { 194, 6, 12 },
                    { 195, 31, 3 },
                    { 196, 16, 10 },
                    { 197, 41, 4 },
                    { 198, 1, 2 },
                    { 199, 11, 15 }
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
                name: "ApplicationUsers");

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
