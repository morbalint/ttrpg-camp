using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Db;

public class TtrpgCampDbContext(DbContextOptions<TtrpgCampDbContext> options) : IdentityDbContext<TtrpgCampUser>(options)
{
    public DbSet<Participant> Participants { get; set; }
    
    public DbSet<Game> Games { get; set; }
    
    public DbSet<GamePlayers> GamePlayers { get; set; }
}