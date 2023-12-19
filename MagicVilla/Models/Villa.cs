namespace MagicVilla.Models
{
    public class Villa
    {
        public int Id { get; set; }
        public string VillaName { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int Ocuppants { get; set; }
        public int SquareMeters { get; set; }
        public string ImagenUrl { get; set; }

        public string Amenidad { get; set; }
        
        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
