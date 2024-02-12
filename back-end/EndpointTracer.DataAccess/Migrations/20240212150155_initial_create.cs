using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EndpointTracer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalDps",
                columns: table => new
                {
                    ExternalDpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DpName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ManagementUrl = table.Column<string>(type: "varchar(200)", nullable: false),
                    Type = table.Column<string>(type: "varchar(20)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalDps", x => x.ExternalDpId);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pem = table.Column<string>(type: "varchar(3000)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "varchar(20)", nullable: false),
                    Desc = table.Column<string>(type: "varchar(1000)", nullable: false),
                    ExternalDpId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_Certificates_ExternalDps_ExternalDpId",
                        column: x => x.ExternalDpId,
                        principalTable: "ExternalDps",
                        principalColumn: "ExternalDpId");
                });

            migrationBuilder.CreateTable(
                name: "EndpointAddresses",
                columns: table => new
                {
                    EndpointAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endpoint = table.Column<string>(type: "varchar(200)", nullable: false),
                    Datapower = table.Column<string>(type: "varchar(200)", nullable: false),
                    Env = table.Column<string>(type: "varchar(20)", nullable: false),
                    ExternalDpId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointAddresses", x => x.EndpointAddressId);
                    table.ForeignKey(
                        name: "FK_EndpointAddresses_ExternalDps_ExternalDpId",
                        column: x => x.ExternalDpId,
                        principalTable: "ExternalDps",
                        principalColumn: "ExternalDpId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ExternalDpId",
                table: "Certificates",
                column: "ExternalDpId");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointAddresses_ExternalDpId",
                table: "EndpointAddresses",
                column: "ExternalDpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "EndpointAddresses");

            migrationBuilder.DropTable(
                name: "ExternalDps");
        }
    }
}
