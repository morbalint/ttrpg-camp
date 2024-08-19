namespace TtrpgCamp.App.Db.Seed;

public interface IAdminSeeder
{
    Task<bool> SeedAdminAsync();
}