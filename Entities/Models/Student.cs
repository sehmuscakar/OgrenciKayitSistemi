namespace Entities.Models
{
    public class Student:BaseEntity
    {
        public DateTime DogumTarihi { get; set; }
        public byte Cinsiyet { get; set; }

        //public string Sinif { get; set; }  // ilk kullanım
        public byte Sinif { get; set; } // Enum olarak tanımladık  
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
