using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseLoop.Core.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Improving_Domain_objects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0df9b19b-d257-4c0e-8e83-7560e8ca339b"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("19b9c1ef-67c2-4c68-86b4-dda8b5e9d0ed"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("36b24253-3b02-4247-a8bc-a8e4cdacbc27"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("703f60de-0659-40d0-acaa-21e21ed23055"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7aa77320-c9f4-4dc3-a4d6-987dad84182e"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8129e2b5-3098-4814-b1ba-0871c796c141"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("98c83533-c119-496a-b15b-cec4e61450db"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("c63a0f51-27ee-41d4-9c8b-ca29a1f36dd3"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("db385dca-faad-4a4d-8ae5-e73fae2287a3"),
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ef2a4705-91a2-407d-8702-a03264581c01"),
                column: "RoleId",
                value: null);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("e1161fa0-27ed-4d7e-ba10-17a2cd295cc4"), "Product Management is system role and represents the role with the ability to manage products. This role cannot be deleted or edited since it's not a user-defined role.", "Product.Management" });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e1161fa0-27ed-4d7e-ba10-17a2cd295cc4"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Permissions");
        }
    }
}
