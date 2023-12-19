using MagicVilla.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Datos
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    VillaName = "Villa real",
                    Details = "",
                    ImagenUrl = "",
                    Ocuppants=5,
                    SquareMeters=50,
                    Price=200,
                    Amenidad="",
                    CreationDate= DateTime.Now,
                    UpdateDate= DateTime.Now,
                   }, new Villa()
                   {
                       Id = 2,
                       VillaName = "Villa con vista a la playa",
                       Details = "Detalle de la vista",
                       ImagenUrl = "",
                       Ocuppants = 6,
                       SquareMeters = 70,
                       Price = 230,
                       Amenidad = "",
                       CreationDate = DateTime.Now,
                       UpdateDate = DateTime.Now,
                   }

                );
                
                



            base.OnModelCreating(modelBuilder);
        }
    }
}
