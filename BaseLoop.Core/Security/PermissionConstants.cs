namespace BaseLoop.Core.Security;

public static class PermissionConstants
{
    public static class UserManagement
    {
        public const string AddUser = "Add.User";
        public const string SearchUser = "Search.User";
        public const string EditUser = "Edit.User";
        public const string DeleteUser = "Delete.User";
        public const string ReadUser = "Read.User";
    }

    public static class RoleManagement
    {
        public const string SearchRoles = "Search.Roles";
        public const string AddRole = "Add.Role";
        public const string EditRole = "Edit.Role";
        public const string DeleteRole = "Delete.Role";
        public const string ReadRole = "Read.Role";
    }

    public static class ProductManagement
    {
        public const string SearchProducts = "Search.Products";
        public const string AddProduct = "Add.Product";
        public const string EditProduct = "Edit.Product";
        public const string DeleteProduct = "Delete.Product";
        public const string ReadProduct = "Read.Product";
    }
}