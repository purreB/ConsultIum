using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultium.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    consultant_ids = table.Column<List<Guid>>(type: "uuid[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "consultants",
                columns: table => new
                {
                    consultant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    skills = table.Column<string[]>(type: "text[]", nullable: false),
                    has_asignment = table.Column<bool>(type: "boolean", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    consultant_ids = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_consultants", x => x.consultant_id);
                    table.ForeignKey(
                        name: "fk_consultants_customers_consultant_ids",
                        column: x => x.consultant_ids,
                        principalTable: "customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "fk_consultants_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_consultants_consultant_ids",
                table: "consultants",
                column: "consultant_ids");

            migrationBuilder.CreateIndex(
                name: "ix_consultants_customer_id",
                table: "consultants",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultants");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
