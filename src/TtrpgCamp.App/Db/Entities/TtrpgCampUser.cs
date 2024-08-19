using Microsoft.AspNetCore.Identity;

namespace TtrpgCamp.App.Db.Entities;

public class TtrpgCampUser : IdentityUser
{
}

public class TtrpgCampRole : IdentityRole
{
    public TtrpgCampRole()
    {
    }
    
    public TtrpgCampRole(string name): base(name)
    {
    }
}