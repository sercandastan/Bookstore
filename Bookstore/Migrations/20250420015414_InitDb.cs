using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookstore.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthYear = table.Column<short>(type: "smallint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    PublicationYear = table.Column<short>(type: "smallint", nullable: false),
                    EditionNumber = table.Column<int>(type: "int", nullable: false),
                    CoverText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CoverImage = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "1e45e12d-3247-47f7-88bb-6a8f18df73b1", "Admin", "ADMIN" },
                    { 2, "cd15ffa4-fb0f-48ec-8151-2e65aad0683b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "3367000c-e282-471c-a01d-256fdafcc155", "admin@admin.com", false, 0, false, null, "Super", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEGcFxZ2aluQvRBT0WkT4u0gXZBqTxYlATu+AnQXmQBvY2bi9JGJzUKewqf2vsfmDbA==", null, false, "09b70f20-1b87-47fa-b617-b48989e8c4d2", "Admin", false, "Admin" },
                    { 2, 0, "b2fb76d9-60c6-4e5d-b3ef-b7736789f689", "sercandastan@hotmail.com", false, 0, false, null, "Sercan", "SERCANDASTAN@HOTMAIL.COM", "SERCANDASTAN", "AQAAAAIAAYagAAAAEKisYljlzbeeh7M+x/8J0KFxxjxSu6scaoQ2mCiaMX2jVEbYdKH6mAEmZuZW8dRddQ==", null, false, "e9e259e7-6028-47e9-9adf-ab33e670175c", "Daştan", false, "sercandastan" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthYear", "CreatedAt", "DeletedAt", "FullName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, (short)1990, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(691), null, "Matt Haig", 0, null },
                    { 2, (short)1903, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(708), null, "George Orwell", 0, null },
                    { 3, (short)1775, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(710), null, "Jane Austen", 0, null },
                    { 4, (short)1947, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(711), null, "Stephen King", 0, null },
                    { 5, (short)1965, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(712), null, "J.K. Rowling", 0, null },
                    { 6, (short)1890, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(713), null, "Agatha Christie", 0, null },
                    { 7, (short)1828, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(714), null, "Leo Tolstoy", 0, null },
                    { 8, (short)1899, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(715), null, "Ernest Hemingway", 0, null },
                    { 9, (short)1949, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(716), null, "Haruki Murakami", 0, null },
                    { 10, (short)1927, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(717), null, "Gabriel Garcia Marquez", 0, null },
                    { 11, (short)1952, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(719), null, "Orhan Pamuk", 0, null },
                    { 12, (short)1971, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(720), null, "Elif Şafak", 0, null },
                    { 13, (short)1821, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(721), null, "Fyodor Dostoevsky", 0, null },
                    { 14, (short)1871, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(722), null, "Marcel Proust", 0, null },
                    { 15, (short)1882, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(723), null, "Virginia Woolf", 0, null },
                    { 16, (short)1877, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(724), null, "Hermann Hesse", 0, null },
                    { 17, (short)1835, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(725), null, "Mark Twain", 0, null },
                    { 18, (short)1883, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(726), null, "Franz Kafka", 0, null },
                    { 19, (short)1947, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(727), null, "Paulo Coelho", 0, null },
                    { 20, (short)1964, new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(810), null, "Dan Brown", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Roman", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(640), null, 0, null },
                    { 2, "Bilim Kurgu", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(646), null, 0, null },
                    { 3, "Korku", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(647), null, 0, null },
                    { 4, "Felsefe", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(648), null, 0, null },
                    { 5, "Polisiye", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(649), null, 0, null },
                    { 6, "Klasik", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(650), null, 0, null },
                    { 7, "Fantastik", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(650), null, 0, null },
                    { 8, "Modern Edebiyat", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(651), null, 0, null },
                    { 9, "Tarih", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(652), null, 0, null },
                    { 10, "Latin Amerika Edebiyatı", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(653), null, 0, null },
                    { 11, "Çocuk", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(654), null, 0, null },
                    { 12, "Psikoloji", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(655), null, 0, null },
                    { 13, "Kişisel Gelişim", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(656), null, 0, null },
                    { 14, "Biyografi", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(657), null, 0, null },
                    { 15, "Gezi", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(658), null, 0, null },
                    { 16, "Sağlık", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(659), null, 0, null },
                    { 17, "Ekonomi", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(660), null, 0, null },
                    { 18, "Sanat", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(660), null, 0, null },
                    { 19, "Şiir", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(661), null, 0, null },
                    { 20, "Çağdaş Dünya Edebiyatı", new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(662), null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "PublisherName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1501), null, "Pegasus Yayınları", 0, null },
                    { 2, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1503), null, "Can Yayınları", 0, null },
                    { 3, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1504), null, "İş Bankası Kültür Yayınları", 0, null },
                    { 4, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1505), null, "Altın Kitaplar", 0, null },
                    { 5, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1506), null, "YKY", 0, null },
                    { 6, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1507), null, "Epsilon Yayınları", 0, null },
                    { 7, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1508), null, "Remzi Kitabevi", 0, null },
                    { 8, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1509), null, "Everest Yayınları", 0, null },
                    { 9, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1510), null, "Doğan Kitap", 0, null },
                    { 10, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1511), null, "Kafka Kitap", 0, null },
                    { 11, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1512), null, "Metis Yayınları", 0, null },
                    { 12, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1513), null, "İthaki Yayınları", 0, null },
                    { 13, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1514), null, "Doğan Egmont", 0, null },
                    { 14, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1515), null, "Tudem Yayınları", 0, null },
                    { 15, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1516), null, "Türkiye İş Bankası Kültür Yayınları", 0, null },
                    { 16, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1516), null, "Omega Yayınları", 0, null },
                    { 17, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1517), null, "Kalem Kitap", 0, null },
                    { 18, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1518), null, "Beyaz Balina Yayınları", 0, null },
                    { 19, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1519), null, "Profil Yayıncılık", 0, null },
                    { 20, new DateTime(2025, 4, 20, 4, 54, 14, 584, DateTimeKind.Local).AddTicks(1520), null, "Dergah Yayınları", 0, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "CoverImage", "CoverText", "CreatedAt", "DeletedAt", "EditionNumber", "Price", "PublicationYear", "PublisherId", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 8, "/BookCoverImages/gyk.jpg", "Hayatın olasılıkları üzerine etkileyici bir hikaye.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2105), null, 1, 120m, (short)2020, 1, 0, "Gece Yarısı Kütüphanesi", null, 1 },
                    { 2, 2, "/BookCoverImages/1984.jpg", "Distopik bir geleceğin sert tasviri.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2109), null, 5, 90m, (short)1949, 2, 0, "1984", null, 1 },
                    { 3, 6, "/BookCoverImages/avg.jpg", "Zarafet ve sınıf çatışmalarının romanı.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2110), null, 3, 85m, (short)1813, 3, 0, "Aşk ve Gurur", null, 1 },
                    { 4, 3, "/BookCoverImages/O.jpg", "Korku dolu bir kasaba ve geçmişin karanlığı.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2112), null, 2, 110m, (short)1986, 4, 0, "O", null, 1 },
                    { 5, 7, "/BookCoverImages/hpvft.jpg", "Büyücü bir çocuğun destansı yolculuğu.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2113), null, 1, 100m, (short)1997, 5, 0, "Harry Potter ve Felsefe Taşı", null, 1 },
                    { 6, 5, "/BookCoverImages/okz.jpg", "Gerilim ve gizemin en iyi örneklerinden.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2115), null, 4, 95m, (short)1939, 6, 0, "On Küçük Zenci", null, 1 },
                    { 7, 9, "/BookCoverImages/svb.jpg", "Rusya'nın tarihsel ve kültürel panoraması.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2116), null, 2, 130m, (short)1869, 7, 0, "Savaş ve Barış", null, 1 },
                    { 8, 1, "/BookCoverImages/yavd.jpg", "Direnişin ve yalnızlığın metaforu.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2118), null, 2, 80m, (short)1952, 8, 0, "Yaşlı Adam ve Deniz", null, 1 },
                    { 9, 2, "/BookCoverImages/1q84.jpg", "Paralel evrende geçen gizemli bir yolculuk.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2119), null, 1, 125m, (short)2009, 9, 0, "1Q84", null, 1 },
                    { 10, 10, "/BookCoverImages/yy.jpg", "Bir ailenin kuşaklar arası büyülü hikayesi.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2121), null, 3, 115m, (short)1967, 10, 0, "Yüzyıllık Yalnızlık", null, 1 },
                    { 11, 3, "/BookCoverImages/korluk.jpg", "Toplumsal çöküşün karanlık portresi.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2122), null, 2, 105m, (short)1995, 11, 0, "Körlük", null, 1 },
                    { 12, 10, "/BookCoverImages/masumiyet.jpg", "Takıntı ile aşkın sınırlarında bir hikaye.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2124), null, 1, 95m, (short)2008, 12, 0, "Masumiyet Müzesi", null, 1 },
                    { 13, 6, "/BookCoverImages/scuzceza.jpg", "Vicdan azabının psikolojik çözümlemesi.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2125), null, 3, 110m, (short)1866, 13, 0, "Suç ve Ceza", null, 1 },
                    { 14, 8, "/BookCoverImages/kayipzaman.jpg", "Belleğin ince notaları.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2127), null, 1, 150m, (short)1913, 14, 0, "Kayıp Zamanın İzinde", null, 1 },
                    { 15, 4, "/BookCoverImages/mrsdalloway.jpg", "Bir günün özenle işlenmiş portresi.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2128), null, 2, 90m, (short)1925, 15, 0, "Mrs Dalloway", null, 1 },
                    { 16, 4, "/BookCoverImages/siddhartha.jpg", "Ruhani yolculuğa dair bir başyapıt.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2130), null, 1, 85m, (short)1922, 16, 0, "Siddhartha", null, 1 },
                    { 17, 1, "/BookCoverImages/tomsawyer.jpg", "Çocukluğun neşeli dünyası.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2131), null, 5, 75m, (short)1876, 17, 0, "Tom Sawyer’ın Maceraları", null, 1 },
                    { 18, 3, "/BookCoverImages/donusum.jpg", "Varoluşsal kaygının sembolik öyküsü.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2133), null, 1, 80m, (short)1915, 18, 0, "Dönüşüm", null, 1 },
                    { 19, 7, "/BookCoverImages/simyaci.jpg", "Rüyanın peşinde bir yolculuk.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2134), null, 3, 95m, (short)1988, 19, 0, "Simyacı", null, 1 },
                    { 20, 2, "/BookCoverImages/davinci.jpg", "Tarih, sanat ve gizemin kesiştiği nokta.", new DateTime(2025, 4, 20, 4, 54, 14, 583, DateTimeKind.Local).AddTicks(2135), null, 2, 120m, (short)2003, 20, 0, "Da Vinci Şifresi", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAt", "DeletedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null },
                    { 2, 2, null, null, null, null },
                    { 3, 3, null, null, null, null },
                    { 4, 4, null, null, null, null },
                    { 5, 5, null, null, null, null },
                    { 6, 6, null, null, null, null },
                    { 7, 7, null, null, null, null },
                    { 8, 8, null, null, null, null },
                    { 9, 9, null, null, null, null },
                    { 10, 10, null, null, null, null },
                    { 11, 11, null, null, null, null },
                    { 12, 12, null, null, null, null },
                    { 13, 13, null, null, null, null },
                    { 14, 14, null, null, null, null },
                    { 15, 15, null, null, null, null },
                    { 16, 16, null, null, null, null },
                    { 17, 17, null, null, null, null },
                    { 18, 18, null, null, null, null },
                    { 19, 19, null, null, null, null },
                    { 20, 20, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BookId",
                table: "Carts",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
