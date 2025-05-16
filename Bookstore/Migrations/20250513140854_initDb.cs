using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookstore.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "29df3d37-3b8b-48ef-bb02-e3e281197ec9", "Admin", "ADMIN" },
                    { 2, "cd81daa5-c7a2-4767-ab60-ddb7b65f6c68", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a3ddacb8-5d98-492d-b91b-820bf77f252b", "admin@admin.com", false, 0, false, null, "Super", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEPALgTzIoYOZ96ZUcArcVSC9CypFwpRcgnQjrdULvVpiTuWs+zWjpb5uJ8N7dnEOPQ==", null, false, "5bf5bfa7-36fb-4254-8aaf-7d39152162f3", "Admin", false, "Admin" },
                    { 2, 0, "9a5d74e9-9b0e-409d-94f2-488cceb2e165", "sercandastan@hotmail.com", false, 0, false, null, "Sercan", "SERCANDASTAN@HOTMAIL.COM", "SERCANDASTAN", "AQAAAAIAAYagAAAAEEsKb9RyZkehpitcVlyhq1gdJGKa+QB+HtXTx1nglpgTPQRTftXDe2rfhrZjiOWo7Q==", null, false, "7f369196-513c-4c5c-a986-32f7c7897b32", "Daştan", false, "sercandastan" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthYear", "CreatedAt", "DeletedAt", "FullName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, (short)1990, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9750), null, "Matt Haig", 0, null },
                    { 2, (short)1903, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9769), null, "George Orwell", 0, null },
                    { 3, (short)1775, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9771), null, "Jane Austen", 0, null },
                    { 4, (short)1947, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9772), null, "Stephen King", 0, null },
                    { 5, (short)1965, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9773), null, "J.K. Rowling", 0, null },
                    { 6, (short)1890, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9774), null, "Agatha Christie", 0, null },
                    { 7, (short)1828, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9775), null, "Leo Tolstoy", 0, null },
                    { 8, (short)1899, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9776), null, "Ernest Hemingway", 0, null },
                    { 9, (short)1949, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9777), null, "Haruki Murakami", 0, null },
                    { 10, (short)1927, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9778), null, "Gabriel Garcia Marquez", 0, null },
                    { 11, (short)1952, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9839), null, "Orhan Pamuk", 0, null },
                    { 12, (short)1971, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9840), null, "Elif Şafak", 0, null },
                    { 13, (short)1821, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9841), null, "Fyodor Dostoevsky", 0, null },
                    { 14, (short)1871, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9842), null, "Marcel Proust", 0, null },
                    { 15, (short)1882, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9843), null, "Virginia Woolf", 0, null },
                    { 16, (short)1877, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9845), null, "Hermann Hesse", 0, null },
                    { 17, (short)1835, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9846), null, "Mark Twain", 0, null },
                    { 18, (short)1883, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9847), null, "Franz Kafka", 0, null },
                    { 19, (short)1947, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9848), null, "Paulo Coelho", 0, null },
                    { 20, (short)1964, new DateTime(2025, 5, 13, 17, 8, 53, 889, DateTimeKind.Local).AddTicks(9849), null, "Dan Brown", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Roman", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6221), null, 0, null },
                    { 2, "Bilim Kurgu", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6226), null, 0, null },
                    { 3, "Korku", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6227), null, 0, null },
                    { 4, "Felsefe", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6228), null, 0, null },
                    { 5, "Polisiye", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6229), null, 0, null },
                    { 6, "Klasik", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6230), null, 0, null },
                    { 7, "Fantastik", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6231), null, 0, null },
                    { 8, "Modern Edebiyat", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6232), null, 0, null },
                    { 9, "Tarih", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6233), null, 0, null },
                    { 10, "Latin Amerika Edebiyatı", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6234), null, 0, null },
                    { 11, "Çocuk", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6234), null, 0, null },
                    { 12, "Psikoloji", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6235), null, 0, null },
                    { 13, "Kişisel Gelişim", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6236), null, 0, null },
                    { 14, "Biyografi", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6237), null, 0, null },
                    { 15, "Gezi", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6238), null, 0, null },
                    { 16, "Sağlık", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6239), null, 0, null },
                    { 17, "Ekonomi", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6240), null, 0, null },
                    { 18, "Sanat", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6241), null, 0, null },
                    { 19, "Şiir", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6242), null, 0, null },
                    { 20, "Çağdaş Dünya Edebiyatı", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(6243), null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "PublisherName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(365), null, "Pegasus Yayınları", 0, null },
                    { 2, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(369), null, "Can Yayınları", 0, null },
                    { 3, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(370), null, "İş Bankası Kültür Yayınları", 0, null },
                    { 4, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(371), null, "Altın Kitaplar", 0, null },
                    { 5, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(372), null, "YKY", 0, null },
                    { 6, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(373), null, "Epsilon Yayınları", 0, null },
                    { 7, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(374), null, "Remzi Kitabevi", 0, null },
                    { 8, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(375), null, "Everest Yayınları", 0, null },
                    { 9, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(376), null, "Doğan Kitap", 0, null },
                    { 10, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(377), null, "Kafka Kitap", 0, null },
                    { 11, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(378), null, "Metis Yayınları", 0, null },
                    { 12, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(379), null, "İthaki Yayınları", 0, null },
                    { 13, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(380), null, "Doğan Egmont", 0, null },
                    { 14, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(381), null, "Tudem Yayınları", 0, null },
                    { 15, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(382), null, "Türkiye İş Bankası Kültür Yayınları", 0, null },
                    { 16, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(383), null, "Omega Yayınları", 0, null },
                    { 17, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(383), null, "Kalem Kitap", 0, null },
                    { 18, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(384), null, "Beyaz Balina Yayınları", 0, null },
                    { 19, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(385), null, "Profil Yayıncılık", 0, null },
                    { 20, new DateTime(2025, 5, 13, 17, 8, 53, 891, DateTimeKind.Local).AddTicks(386), null, "Dergah Yayınları", 0, null }
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
                    { 1, 8, "/BookCoverImages/gyk.jpg", "Hayatın olasılıkları üzerine etkileyici bir hikaye.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1162), null, 1, 120m, (short)2020, 1, "Added", "Gece Yarısı Kütüphanesi", null, 1 },
                    { 2, 2, "/BookCoverImages/1984.jpg", "Distopik bir geleceğin sert tasviri.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1166), null, 5, 90m, (short)1949, 2, "Added", "1984", null, 1 },
                    { 3, 6, "/BookCoverImages/avg.jpg", "Zarafet ve sınıf çatışmalarının romanı.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1168), null, 3, 85m, (short)1813, 3, "Added", "Aşk ve Gurur", null, 1 },
                    { 4, 3, "/BookCoverImages/O.jpg", "Korku dolu bir kasaba ve geçmişin karanlığı.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1170), null, 2, 110m, (short)1986, 4, "Added", "O", null, 1 },
                    { 5, 7, "/BookCoverImages/hpvft.jpg", "Büyücü bir çocuğun destansı yolculuğu.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1172), null, 1, 100m, (short)1997, 5, "Added", "Harry Potter ve Felsefe Taşı", null, 1 },
                    { 6, 5, "/BookCoverImages/okz.jpg", "Gerilim ve gizemin en iyi örneklerinden.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1173), null, 4, 95m, (short)1939, 6, "Added", "On Küçük Zenci", null, 1 },
                    { 7, 9, "/BookCoverImages/svb.jpg", "Rusya'nın tarihsel ve kültürel panoraması.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1201), null, 2, 130m, (short)1869, 7, "Added", "Savaş ve Barış", null, 1 },
                    { 8, 1, "/BookCoverImages/yavd.jpg", "Direnişin ve yalnızlığın metaforu.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1203), null, 2, 80m, (short)1952, 8, "Added", "Yaşlı Adam ve Deniz", null, 1 },
                    { 9, 2, "/BookCoverImages/1q84.jpg", "Paralel evrende geçen gizemli bir yolculuk.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1205), null, 1, 125m, (short)2009, 9, "Added", "1Q84", null, 1 },
                    { 10, 10, "/BookCoverImages/yy.jpg", "Bir ailenin kuşaklar arası büyülü hikayesi.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1206), null, 3, 115m, (short)1967, 10, "Added", "Yüzyıllık Yalnızlık", null, 1 },
                    { 11, 3, "/BookCoverImages/korluk.jpg", "Toplumsal çöküşün karanlık portresi.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1208), null, 2, 105m, (short)1995, 11, "Added", "Körlük", null, 1 },
                    { 12, 10, "/BookCoverImages/masumiyet.jpg", "Takıntı ile aşkın sınırlarında bir hikaye.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1210), null, 1, 95m, (short)2008, 12, "Added", "Masumiyet Müzesi", null, 1 },
                    { 13, 6, "/BookCoverImages/scuzceza.jpg", "Vicdan azabının psikolojik çözümlemesi.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1212), null, 3, 110m, (short)1866, 13, "Added", "Suç ve Ceza", null, 1 },
                    { 14, 8, "/BookCoverImages/kayipzaman.jpg", "Belleğin ince notaları.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1214), null, 1, 150m, (short)1913, 14, "Added", "Kayıp Zamanın İzinde", null, 1 },
                    { 15, 4, "/BookCoverImages/mrsdalloway.jpg", "Bir günün özenle işlenmiş portresi.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1215), null, 2, 90m, (short)1925, 15, "Added", "Mrs Dalloway", null, 1 },
                    { 16, 4, "/BookCoverImages/siddhartha.jpg", "Ruhani yolculuğa dair bir başyapıt.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1217), null, 1, 85m, (short)1922, 16, "Added", "Siddhartha", null, 1 },
                    { 17, 1, "/BookCoverImages/tomsawyer.jpg", "Çocukluğun neşeli dünyası.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1219), null, 5, 75m, (short)1876, 17, "Added", "Tom Sawyer’ın Maceraları", null, 1 },
                    { 18, 3, "/BookCoverImages/donusum.jpg", "Varoluşsal kaygının sembolik öyküsü.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1221), null, 1, 80m, (short)1915, 18, "Added", "Dönüşüm", null, 1 },
                    { 19, 7, "/BookCoverImages/simyaci.jpg", "Rüyanın peşinde bir yolculuk.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1222), null, 3, 95m, (short)1988, 19, "Added", "Simyacı", null, 1 },
                    { 20, 2, "/BookCoverImages/davinci.jpg", "Tarih, sanat ve gizemin kesiştiği nokta.", new DateTime(2025, 5, 13, 17, 8, 53, 890, DateTimeKind.Local).AddTicks(1224), null, 2, 120m, (short)2003, 20, "Added", "Da Vinci Şifresi", null, 1 }
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
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
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
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
