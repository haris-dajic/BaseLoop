using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseLoop.Core.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BaseIdentityStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Domain", "Name" },
                values: new object[,]
                {
                    { new Guid("0df9b19b-d257-4c0e-8e83-7560e8ca339b"), "Ability to see a page with a list of users alongside with search functionality.", 1, "Search.User" },
                    { new Guid("19b9c1ef-67c2-4c68-86b4-dda8b5e9d0ed"), "Ability to navigate to user details page without ability to edit user. Required Permissions: Search.Users", 1, "Read.User" },
                    { new Guid("36b24253-3b02-4247-a8bc-a8e4cdacbc27"), "Ability to navigate to role details page and edit role. Required Permissions: Search.Roles", 2, "Edit.Role" },
                    { new Guid("703f60de-0659-40d0-acaa-21e21ed23055"), "Ability to navigate to user details page and edit user. Required Permissions: Search.Users", 1, "Edit.User" },
                    { new Guid("7aa77320-c9f4-4dc3-a4d6-987dad84182e"), "Ability to see delete action alongside with ability to delete user. Required Permissions: Search.Users, Edit.User", 1, "Delete.User" },
                    { new Guid("8129e2b5-3098-4814-b1ba-0871c796c141"), "Ability to see button for add user alongside with ability to create user. Required Permissions: Search.Users", 1, "Add.User" },
                    { new Guid("98c83533-c119-496a-b15b-cec4e61450db"), "Ability to see delete action alongside with ability to delete role. Required Permissions: Search.Roles, Edit.Roles", 2, "Delete.Role" },
                    { new Guid("c63a0f51-27ee-41d4-9c8b-ca29a1f36dd3"), "Ability to see button for add role alongside with ability to create role. Required Permissions: Search.Roles", 2, "Add.Role" },
                    { new Guid("db385dca-faad-4a4d-8ae5-e73fae2287a3"), "Ability to navigate to role details page without ability to edit role. Required Permissions: Search.Roles", 2, "Read.Role" },
                    { new Guid("ef2a4705-91a2-407d-8702-a03264581c01"), "Ability to see a page with a list of roles alongside with search functionality.", 2, "Search.Roles" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3f548f0f-bceb-4c5e-9fa5-5e82f8fd63c9"), "User Management is a system role and represents the role with the ability to manage users. This role cannot be deleted or edited since it's not a user-defined role.", "User.Management" },
                    { new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc"), "System Administrator Role is a system role and represents the role with the ability to managing users and roles. This role cannot be deleted or edit since it's not a user-defined role.", "System.Administrator" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc"), new Guid("0f530343-18f4-4d9d-bc0b-6375a7fe905c") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Birthday", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new Guid("0f530343-18f4-4d9d-bc0b-6375a7fe905c"), "Aleja Bosne Srebrene 77", new DateTime(1995, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "Admin", "$2b$10$MSaUX8lTLYDVGV03kS3jF.ztL1oL2a4fJlyMBfYGO5vPJ5hd7lXdi", "$2b$10$MSaUX8lTLYDVGV03kS3jF.", "admin" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0df9b19b-d257-4c0e-8e83-7560e8ca339b"), new Guid("3f548f0f-bceb-4c5e-9fa5-5e82f8fd63c9") },
                    { new Guid("0df9b19b-d257-4c0e-8e83-7560e8ca339b"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("19b9c1ef-67c2-4c68-86b4-dda8b5e9d0ed"), new Guid("3f548f0f-bceb-4c5e-9fa5-5e82f8fd63c9") },
                    { new Guid("19b9c1ef-67c2-4c68-86b4-dda8b5e9d0ed"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("36b24253-3b02-4247-a8bc-a8e4cdacbc27"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("703f60de-0659-40d0-acaa-21e21ed23055"), new Guid("3f548f0f-bceb-4c5e-9fa5-5e82f8fd63c9") },
                    { new Guid("703f60de-0659-40d0-acaa-21e21ed23055"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("7aa77320-c9f4-4dc3-a4d6-987dad84182e"), new Guid("3f548f0f-bceb-4c5e-9fa5-5e82f8fd63c9") },
                    { new Guid("7aa77320-c9f4-4dc3-a4d6-987dad84182e"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("8129e2b5-3098-4814-b1ba-0871c796c141"), new Guid("3f548f0f-bceb-4c5e-9fa5-5e82f8fd63c9") },
                    { new Guid("8129e2b5-3098-4814-b1ba-0871c796c141"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("98c83533-c119-496a-b15b-cec4e61450db"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("c63a0f51-27ee-41d4-9c8b-ca29a1f36dd3"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("db385dca-faad-4a4d-8ae5-e73fae2287a3"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") },
                    { new Guid("ef2a4705-91a2-407d-8702-a03264581c01"), new Guid("edd3f7db-7b67-4a18-a337-3a23971b3bfc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0f530343-18f4-4d9d-bc0b-6375a7fe905c"));
        }
    }
}
