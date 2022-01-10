using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Services
{
    public class ApplicationContext : DbContext
    {
        private DbSet<Monster> Monsters { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mage = new Monster()
            {
                Id = 1,
                Name = "Mage",
                HitPoints = 40,
                AttackModifier = 3,
                AttackPerRound = 4,
                Damage = "1d4",
                DamageModifier = 2,
                ArmorClass = 12
            };
            var lemure = new Monster()
            {
                Id = 2,
                Name = "Lemure",
                HitPoints = 13,
                AttackModifier = 3,
                AttackPerRound = 1,
                Damage = "1d4",
                DamageModifier = 0,
                ArmorClass = 7
            };
            var abbot = new Monster()
            {
                Id = 3,
                Name = "Abbot",
                HitPoints = 136,
                AttackModifier = 4,
                AttackPerRound = 2,
                Damage = "4d8",
                DamageModifier = 4,
                ArmorClass = 17
            };
            modelBuilder.Entity<Monster>().HasData(mage, lemure, abbot);
            base.OnModelCreating(modelBuilder);
        }
    }
}