using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultium.Api.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_consultants_customers_customer_id",
                table: "consultants");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                table: "consultants",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_consultants_customers_customer_id",
                table: "consultants",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_consultants_customers_customer_id",
                table: "consultants");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                table: "consultants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_consultants_customers_customer_id",
                table: "consultants",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
