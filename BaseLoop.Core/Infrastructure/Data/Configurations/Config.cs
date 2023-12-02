using BaseLoop.Core.Domain.Identity;
using BaseLoop.Core.Security;

namespace BaseLoop.Core.Infrastructure.Data.Configurations;

public static class Config
{
    public static IList<Permission> GetPermissions()
    {
        var permissions = new List<Permission>();

        permissions.AddRange(UserManagementPermissions());
        permissions.AddRange(GetRoleManagementPermissions());

        return permissions;
    }

    public static IList<Role> GetRoles()
    {
        return new List<Role>
        {
            new()
            {
                Id = new Guid("EDD3F7DB-7B67-4A18-A337-3A23971B3BFC"),
                Name = RoleConstants.SystemAdministratorRole,
                Description =
                    "System Administrator Role is a system role and represents the role with the ability to managing users and roles. This role cannot be deleted or edit since it's not a user-defined role."
            },
            new()
            {
                Id = new Guid("3F548F0F-BCEB-4C5E-9FA5-5E82F8FD63C9"),
                Name = RoleConstants.UserManagementRole,
                Description =
                    "User Management is a system role and represents the role with the ability to manage users. This role cannot be deleted or edited since it's not a user-defined role."
            },
            new()
            {
                Id = new Guid("E1161FA0-27ED-4D7E-BA10-17A2CD295CC4"),
                Name = RoleConstants.ProductManagementRole,
                Description =
                    "Product Management is system role and represents the role with the ability to manage products. This role cannot be deleted or edited since it's not a user-defined role."
            }
        };
    }

    #region UserManagementPermissions

    private static IList<Permission> UserManagementPermissions()
    {
        return new List<Permission>
        {
            new()
            {
                Id = new Guid("0DF9B19B-D257-4C0E-8E83-7560E8CA339B"),
                Name = PermissionConstants.UserManagement.SearchUser,
                Domain = PermissionDomain.UserManagement,
                Description = "Ability to see a page with a list of users alongside with search functionality."
            },
            new()
            {
                Id = new Guid("8129E2B5-3098-4814-B1BA-0871C796C141"),
                Name = PermissionConstants.UserManagement.AddUser,
                Domain = PermissionDomain.UserManagement,
                Description =
                    "Ability to see button for add user alongside with ability to create user. Required Permissions: Search.Users"
            },
            new()
            {
                Id = new Guid("703F60DE-0659-40D0-ACAA-21E21ED23055"),
                Name = PermissionConstants.UserManagement.EditUser,
                Domain = PermissionDomain.UserManagement,
                Description =
                    "Ability to navigate to user details page and edit user. Required Permissions: Search.Users"
            },
            new()
            {
                Id = new Guid("7AA77320-C9F4-4DC3-A4D6-987DAD84182E"),
                Name = PermissionConstants.UserManagement.DeleteUser,
                Domain = PermissionDomain.UserManagement,
                Description =
                    "Ability to see delete action alongside with ability to delete user. Required Permissions: Search.Users, Edit.User"
            },
            new()
            {
                Id = new Guid("19B9C1EF-67C2-4C68-86B4-DDA8B5E9D0ED"),
                Name = PermissionConstants.UserManagement.ReadUser,
                Domain = PermissionDomain.UserManagement,
                Description =
                    "Ability to navigate to user details page without ability to edit user. Required Permissions: Search.Users"
            }
        };
    }

    #endregion

    #region RoleManagementPermissions

    private static IList<Permission> GetRoleManagementPermissions()
    {
        return new List<Permission>
        {
            new()
            {
                Id = new Guid("EF2A4705-91A2-407D-8702-A03264581C01"),
                Name = PermissionConstants.RoleManagement.SearchRoles,
                Domain = PermissionDomain.RoleManagement,
                Description = "Ability to see a page with a list of roles alongside with search functionality."
            },
            new()
            {
                Id = new Guid("C63A0F51-27EE-41D4-9C8B-CA29A1F36DD3"),
                Name = PermissionConstants.RoleManagement.AddRole,
                Domain = PermissionDomain.RoleManagement,
                Description =
                    "Ability to see button for add role alongside with ability to create role. Required Permissions: Search.Roles"
            },
            new()
            {
                Id = new Guid("36B24253-3B02-4247-A8BC-A8E4CDACBC27"),
                Name = PermissionConstants.RoleManagement.EditRole,
                Domain = PermissionDomain.RoleManagement,
                Description =
                    "Ability to navigate to role details page and edit role. Required Permissions: Search.Roles"
            },
            new()
            {
                Id = new Guid("98C83533-C119-496A-B15B-CEC4E61450DB"),
                Name = PermissionConstants.RoleManagement.DeleteRole,
                Domain = PermissionDomain.RoleManagement,
                Description =
                    "Ability to see delete action alongside with ability to delete role. Required Permissions: Search.Roles, Edit.Roles"
            },
            new()
            {
                Id = new Guid("DB385DCA-FAAD-4A4D-8AE5-E73FAE2287A3"),
                Name = PermissionConstants.RoleManagement.ReadRole,
                Domain = PermissionDomain.RoleManagement,
                Description =
                    "Ability to navigate to role details page without ability to edit role. Required Permissions: Search.Roles"
            }
        };
    }

    #endregion

    #region ProductManagementPermissions

    private static IList<Permission> ProductManagementPermissions()
    {
        return new List<Permission>
        {
            new()
            {
                Id = new Guid("25262073-A9C9-42B3-A9A2-7C0190739B1D"),
                Name = PermissionConstants.ProductManagement.SearchProducts,
                Domain = PermissionDomain.ProductManagement,
                Description = "Ability to see a page with a list of products alongside with search functionality"
            },
            new()
            {
                Id = new Guid("FD40703B-25BA-4AC7-8EB5-87B888DE55FE"),
                Name = PermissionConstants.ProductManagement.AddProduct,
                Domain = PermissionDomain.ProductManagement,
                Description =
                    "Ability to see button for add product alongside with ability to create product. Required Permissions: Search.Products"
            },
            new()
            {
                Id = new Guid("7F9994A8-4FE0-4638-95AA-F729C8ADE318"),
                Name = PermissionConstants.ProductManagement.EditProduct,
                Domain = PermissionDomain.ProductManagement,
                Description =
                    "Ability to navigate to product details page and edit product. Required Permissions: Search.Products"
            },
            new()
            {
                Id = new Guid("7FCC4B60-F61E-4D88-849E-14F462BA0067"),
                Name = PermissionConstants.ProductManagement.DeleteProduct,
                Domain = PermissionDomain.ProductManagement,
                Description =
                    "Ability to see delete action alongside with ability to delete product. Required Permissions: Search.Products, Edit.Product"
            },
            new()
            {
                Id = new Guid("C8AFC61D-FB8B-4B13-8AAD-5DE534795EAA"),
                Name = PermissionConstants.ProductManagement.ReadProduct,
                Domain = PermissionDomain.ProductManagement,
                Description =
                    "Ability to navigate to product details page without ability to edit product. Required Permissions: Search.Products"
            }
        };
    }

    #endregion
}