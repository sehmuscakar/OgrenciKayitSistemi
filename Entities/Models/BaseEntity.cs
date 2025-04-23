using Core.Entities;

namespace Entities.Models
{
    public class BaseEntity:IEntity
    {
     //   Ortak Alanları Tek Bir Yerde Tanımlar: Id, Ad, Soyad, Image gibi tüm entity'lerde olması gereken alanları burada tanımlarsın.
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Image { get; set; }
    }
}
