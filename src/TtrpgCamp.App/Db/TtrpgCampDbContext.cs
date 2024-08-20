using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Db;

public class TtrpgCampDbContext : 
    IdentityDbContext<TtrpgCampUser, TtrpgCampRole, string>
{
    public TtrpgCampDbContext()
    {
    }

    public TtrpgCampDbContext(DbContextOptions<TtrpgCampDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Participant> Participants { get; set; }
    
    public virtual DbSet<Game> Games { get; set; }
    
    public virtual DbSet<GamePlayers> GamePlayers { get; set; }
}