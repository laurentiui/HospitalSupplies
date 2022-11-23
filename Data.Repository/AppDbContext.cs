using Data.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository {
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Instrument> Instruments { get; set; }
        //DbSet<User> Users { get; set; }
        //DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrument>().HasData(
                new Instrument() {
                    Id = 1,
                    Name = "RAGNELL STILLE  SUPERCUT BLEPHAROPLASTY SCISSORS",
                    Color = "Red"
                }
                );
            //modelBuilder.Entity<User>().HasData(
            //    new User()
            //    {
            //        Id=1,
            //        Username = "admin",
            //        Email="admin@apistarter.com",
            //        //TODO: never ever leave this admin user here. alwyas change this after a deploy
            //        Password = Utilities.Crypt.CreateMD5("admin"),
            //        IsAllowed = true
            //    },
            //    new User()
            //    {
            //        Id = 2,
            //        Username = "brown-candies",
            //        Email = "brwon-candies@apistarter.com",
            //        Password = Utilities.Crypt.CreateMD5("1"),
            //        IsAllowed = false
            //    }
            //);


            
        }
    }
}
