using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TahaMucasirogluBlog.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AutoMig_2025_7_12_21_26_47 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExperienceTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_ExperienceTypes_ExperienceTypeId",
                        column: x => x.ExperienceTypeId,
                        principalSchema: "dbo",
                        principalTable: "ExperienceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubSkills",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SkillId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "dbo",
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubSkills_Skills_SkillId1",
                        column: x => x.SkillId1,
                        principalSchema: "dbo",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExperienceTechnologies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubSkillId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceTechnologies_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalSchema: "dbo",
                        principalTable: "Experiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExperienceTechnologies_SubSkills_SubSkillId",
                        column: x => x.SubSkillId,
                        principalSchema: "dbo",
                        principalTable: "SubSkills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExperienceTechnologies_SubSkills_SubSkillId1",
                        column: x => x.SubSkillId1,
                        principalSchema: "dbo",
                        principalTable: "SubSkills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogPostsCategory",
                schema: "dbo",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostsCategory", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_BlogPostsCategory_BlogPosts_PostId",
                        column: x => x.PostId,
                        principalSchema: "dbo",
                        principalTable: "BlogPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogPostsCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogPostsTag",
                schema: "dbo",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostsTag", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_BlogPostsTag_BlogPosts_PostId",
                        column: x => x.PostId,
                        principalSchema: "dbo",
                        principalTable: "BlogPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogPostsTag_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "dbo",
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    InsertedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_BlogPosts_PostId",
                        column: x => x.PostId,
                        principalSchema: "dbo",
                        principalTable: "BlogPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalSchema: "dbo",
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_AuthorId",
                schema: "dbo",
                table: "BlogPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Id",
                schema: "dbo",
                table: "BlogPosts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Id_IsDeleted",
                schema: "dbo",
                table: "BlogPosts",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_IsDeleted",
                schema: "dbo",
                table: "BlogPosts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Slug",
                schema: "dbo",
                table: "BlogPosts",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsCategory_CategoryId",
                schema: "dbo",
                table: "BlogPostsCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsCategory_Id",
                schema: "dbo",
                table: "BlogPostsCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsCategory_Id_IsDeleted",
                schema: "dbo",
                table: "BlogPostsCategory",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsCategory_IsDeleted",
                schema: "dbo",
                table: "BlogPostsCategory",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsTag_Id",
                schema: "dbo",
                table: "BlogPostsTag",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsTag_Id_IsDeleted",
                schema: "dbo",
                table: "BlogPostsTag",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsTag_IsDeleted",
                schema: "dbo",
                table: "BlogPostsTag",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsTag_TagId",
                schema: "dbo",
                table: "BlogPostsTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                schema: "dbo",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id_IsDeleted",
                schema: "dbo",
                table: "Categories",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IsDeleted",
                schema: "dbo",
                table: "Categories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                schema: "dbo",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Slug",
                schema: "dbo",
                table: "Categories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Id",
                schema: "dbo",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Id_IsDeleted",
                schema: "dbo",
                table: "Comments",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IsDeleted",
                schema: "dbo",
                table: "Comments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                schema: "dbo",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                schema: "dbo",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ExperienceTypeId",
                schema: "dbo",
                table: "Experiences",
                column: "ExperienceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Id",
                schema: "dbo",
                table: "Experiences",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Id_IsDeleted",
                schema: "dbo",
                table: "Experiences",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_IsDeleted",
                schema: "dbo",
                table: "Experiences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTechnologies_ExperienceId_SubSkillId",
                schema: "dbo",
                table: "ExperienceTechnologies",
                columns: new[] { "ExperienceId", "SubSkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTechnologies_Id",
                schema: "dbo",
                table: "ExperienceTechnologies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTechnologies_Id_IsDeleted",
                schema: "dbo",
                table: "ExperienceTechnologies",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTechnologies_IsDeleted",
                schema: "dbo",
                table: "ExperienceTechnologies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTechnologies_SubSkillId",
                schema: "dbo",
                table: "ExperienceTechnologies",
                column: "SubSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTechnologies_SubSkillId1",
                schema: "dbo",
                table: "ExperienceTechnologies",
                column: "SubSkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTypes_Id",
                schema: "dbo",
                table: "ExperienceTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTypes_Id_IsDeleted",
                schema: "dbo",
                table: "ExperienceTypes",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTypes_IsDeleted",
                schema: "dbo",
                table: "ExperienceTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTypes_Name",
                schema: "dbo",
                table: "ExperienceTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infos_Id",
                schema: "dbo",
                table: "Infos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_Id_IsDeleted",
                schema: "dbo",
                table: "Infos",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Infos_IsDeleted",
                schema: "dbo",
                table: "Infos",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Id",
                schema: "dbo",
                table: "Skills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Id_IsDeleted",
                schema: "dbo",
                table: "Skills",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsDeleted",
                schema: "dbo",
                table: "Skills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Name",
                schema: "dbo",
                table: "Skills",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_Id",
                schema: "dbo",
                table: "SocialLinks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_Id_IsDeleted",
                schema: "dbo",
                table: "SocialLinks",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_IsDeleted",
                schema: "dbo",
                table: "SocialLinks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkills_Id",
                schema: "dbo",
                table: "SubSkills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkills_Id_IsDeleted",
                schema: "dbo",
                table: "SubSkills",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_SubSkills_IsDeleted",
                schema: "dbo",
                table: "SubSkills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkills_SkillId_Name",
                schema: "dbo",
                table: "SubSkills",
                columns: new[] { "SkillId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubSkills_SkillId1",
                schema: "dbo",
                table: "SubSkills",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Id",
                schema: "dbo",
                table: "Tags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Id_IsDeleted",
                schema: "dbo",
                table: "Tags",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_IsDeleted",
                schema: "dbo",
                table: "Tags",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Slug",
                schema: "dbo",
                table: "Tags",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                schema: "dbo",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_IsDeleted",
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsDeleted",
                schema: "dbo",
                table: "Users",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostsCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BlogPostsTag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExperienceTechnologies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Infos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SocialLinks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BlogPosts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubSkills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExperienceTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "dbo");
        }
    }
}
