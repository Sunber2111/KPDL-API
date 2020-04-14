using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    NameLogin = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    IdTeacher = table.Column<Guid>(nullable: false),
                    IsEnable = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_1", x => x.NameLogin);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Sex = table.Column<bool>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Sex = table.Column<bool>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TK = table.Column<double>(nullable: true),
                    GK = table.Column<double>(nullable: true),
                    CK = table.Column<double>(nullable: true),
                    TH = table.Column<double>(nullable: true),
                    IdStudent = table.Column<Guid>(nullable: true),
                    IdSubject = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointTest_Student",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointTest_Subject",
                        column: x => x.IdSubject,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teaching",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdSubject = table.Column<Guid>(nullable: true),
                    IdTeacher = table.Column<Guid>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    TeachDay = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaching", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teaching_Subject",
                        column: x => x.IdSubject,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teaching_Teacher",
                        column: x => x.IdTeacher,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointTest_IdStudent",
                table: "PointTest",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_PointTest_IdSubject",
                table: "PointTest",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_IdSubject",
                table: "Teaching",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_IdTeacher",
                table: "Teaching",
                column: "IdTeacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "PointTest");

            migrationBuilder.DropTable(
                name: "Teaching");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
