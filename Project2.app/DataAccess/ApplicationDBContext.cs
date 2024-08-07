using Microsoft.EntityFrameworkCore;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Spell> Spells { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
        .HasOne(p => p.AccountOwner)
        .WithOne(a => a.OwnedPlayer)
        .HasForeignKey<Player>(p => p.PlayerId);

        modelBuilder.Entity<Enemy>().HasData(new Enemy { EnemyId = 1, EnemyName = "Angry Wolf", Attack = 1, Health = 3, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=end-the-festivities" });

        modelBuilder.Entity<Room>().HasData(new Room { RoomId = 1, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=bayou" });

        modelBuilder.Entity<Item>().HasData(new Item { ItemId = 1, ItemName = "Bronze Sword", Attack = 1, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=bronze-sword" });

        modelBuilder.Entity<Spell>().HasData(new Spell { SpellId = 1, SpellName = "Lightning Bolt", Attack = 2, ManaCost = 1, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=lightning-bolt" });
    }


}