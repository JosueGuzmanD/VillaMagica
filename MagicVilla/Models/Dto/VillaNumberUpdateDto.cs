using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models.Dto
{
    public class VillaNumberUpdateDto
    {
        [Required]
        public int VillaNmber { get; set; }

        [Required]
        public int VillaId { get; set; }

        public string VillaDetails { get; set; }


    }
}
