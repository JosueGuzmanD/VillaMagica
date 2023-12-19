using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models.Dto
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string VillaName { get; set; }
        public string Details { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]    
        public int Ocuppants { get; set; }
        [Required]
        public int SquareMeters { get; set; }
        [Required]
        public string ImagenUrl { get; set; }

        public string Amenidad { get; set; }

    }
}
