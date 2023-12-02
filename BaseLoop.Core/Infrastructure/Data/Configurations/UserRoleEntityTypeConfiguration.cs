// using BaseLoop.Core.Domain.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace BaseLoop.Core.Infrastructure.Data.Configurations;
//
// public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
// {
//     public void Configure(EntityTypeBuilder<UserRole> builder)
//     {
//         builder.HasKey(ur => new { ur.UserId, ur.RoleId });
//         builder.ToTable("UserRoles");
//
//         builder.HasData(new UserRole
//         {
//             UserId = new Guid("0F530343-18F4-4D9D-BC0B-6375A7FE905C"),
//             RoleId = new Guid("EDD3F7DB-7B67-4A18-A337-3A23971B3BFC")
//         });
//     }
// }

