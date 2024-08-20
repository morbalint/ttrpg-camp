using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Db.Seed;

public class AdminSeeder(
    UserManager<TtrpgCampUser> userManager,
    RoleManager<TtrpgCampRole> roleManager,
    ILogger<AdminSeeder> logger,
    IOptionsSnapshot<SeedDto> seed) : IAdminSeeder
{
    public const string AdminRoleName = "admin";
    
    public async Task<bool> SeedAdminAsync()
    {
        var adminUser = await userManager.FindByEmailAsync(seed.Value.AdminEmail);
        if (adminUser == null)
        {
            adminUser = new TtrpgCampUser
            {
                Email = seed.Value.AdminEmail,
                UserName = seed.Value.AdminEmail,
            };
            var createUserResult = await userManager.CreateAsync(adminUser, seed.Value.AdminPassword);
            if (!createUserResult.Succeeded)
            {
                logger.LogError("Failed to create admin user: {errors}", createUserResult.Errors);
                return false;
            }
        }

        if (!adminUser.EmailConfirmed)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(adminUser);
            var confirmEmailResult = await userManager.ConfirmEmailAsync(adminUser, token);
            if (!confirmEmailResult.Succeeded)
            {
                logger.LogError("Failed to confirm admin user: {errors}", confirmEmailResult.Errors);
                return false;
            }
        }

        var adminRole = roleManager.Roles.FirstOrDefault(x => x.Name == AdminRoleName);
        if (adminRole == null)
        {
            adminRole = new TtrpgCampRole(AdminRoleName);
            var createRoleResult = await roleManager.CreateAsync(adminRole);
            if (!createRoleResult.Succeeded)
            {
                logger.LogError("Failed to create admin role: {errors}", createRoleResult.Errors);
                return false;
            }
        }

        if (!await userManager.IsInRoleAsync(adminUser, AdminRoleName))
        {
            var addToRoleResult = await userManager.AddToRoleAsync(adminUser, AdminRoleName);
            if (!addToRoleResult.Succeeded)
            {
                logger.LogError("Failed to add admin user to the admin role: {errors}", addToRoleResult.Errors);
                return false;
            }
        }
        
        return true;
    }
}