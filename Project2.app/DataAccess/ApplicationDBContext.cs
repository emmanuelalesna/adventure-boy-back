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
    public DbSet<Spell> Spells { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
        .HasOne(p => p.AccountOwner)
        .WithOne(a => a.OwnedPlayer)
        .HasForeignKey<Player>(p => p.PlayerId);

        //room 1 information
        modelBuilder.Entity<Enemy>().HasData(new Enemy { EnemyId = 1, EnemyName = "Angry Wolf", Attack = 1, Health = 3, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=end-the-festivities" });

        modelBuilder.Entity<Room>().HasData(new Room { RoomId = 1, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=bayou" });

        modelBuilder.Entity<Item>().HasData(new Item { ItemId = 1, ItemName = "Bronze Sword", Attack = 1, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=bronze-sword" });

        modelBuilder.Entity<Spell>().HasData(new Spell { SpellId = 1, SpellName = "Lightning Bolt", Attack = 2, ManaCost = 1, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=lightning-bolt" });

        //room 2 information

        modelBuilder.Entity<Enemy>().HasData(new Enemy { EnemyId = 2, EnemyName = "Evil Skeleton", Attack = 2, Health = 5, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=manor-skeleton" });

        modelBuilder.Entity<Room>().HasData(new Room { RoomId = 2, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=throne-of-the-high-city" });

        modelBuilder.Entity<Item>().HasData(new Item { ItemId = 2, ItemName = "Iron Sword", Attack = 2, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=greatsword" });

        modelBuilder.Entity<Spell>().HasData(new Spell { SpellId = 2, SpellName = "Fire Blast", Attack = 3, ManaCost = 2, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=fireblast" });

        //room 3 information

        modelBuilder.Entity<Enemy>().HasData(new Enemy { EnemyId = 3, EnemyName = "Pirate", Attack = 3, Health = 11, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=dire-fleet-captain" });

        modelBuilder.Entity<Room>().HasData(new Room { RoomId = 3, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=pirate-ship" });

        modelBuilder.Entity<Item>().HasData(new Item { ItemId = 3, ItemName = "Platinum Mace", Attack = 3, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=manaforce-mace" });

        modelBuilder.Entity<Spell>().HasData(new Spell { SpellId = 3, SpellName = "Deep Freeze", Attack = 4, ManaCost = 3, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=deep-freeze" });

        //room 4 information

        modelBuilder.Entity<Enemy>().HasData(new Enemy { EnemyId = 4, EnemyName = "Zombie", Attack = 4, Health = 17, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=gravecrawler" });

        modelBuilder.Entity<Room>().HasData(new Room { RoomId = 4, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=homicidal-seclusion" });

        modelBuilder.Entity<Item>().HasData(new Item { ItemId = 4, ItemName = "Fire Ice Sword", Attack = 4, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=sword-of-fire-and-ice" });

        modelBuilder.Entity<Spell>().HasData(new Spell { SpellId = 4, SpellName = "Poison Spell", Attack = 5, ManaCost = 4, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=anoint-with-affliction" });

        //room 5 information

        modelBuilder.Entity<Enemy>().HasData(new Enemy { EnemyId = 5, EnemyName = "Dragon", Attack = 5, Health = 22, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=broodmate-dragon" });

        modelBuilder.Entity<Room>().HasData(new Room { RoomId = 5, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=darigaaz's-caldera" });

        modelBuilder.Entity<Item>().HasData(new Item { ItemId = 5, ItemName = "Death Sword", Attack = 5, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=deathrender" });

        modelBuilder.Entity<Spell>().HasData(new Spell { SpellId = 5, SpellName = "Magic Missile", Attack = 6, ManaCost = 5, ImageUrl = "https://api.scryfall.com/cards/named?fuzzy=magic-missile" });
    }




}