using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        public string VillaName { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int Ocuppants { get; set; }
        public int SquareMeters { get; set; }
        public string ImagenUrl { get; set; }

        public string Amenidad { get; set; }

    }
}
