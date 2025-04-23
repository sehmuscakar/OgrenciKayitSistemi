using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class StudentModel:BaseEntity
    {
        public DateTime DogumTarihi { get; set; }
        public byte Cinsiyet { get; set; }

        //public string Sinif { get; set; }  // ilk kullanım
        public byte Sinif { get; set; } // Enum olarak tanımladık  
        public string TeacherFullName { get; set; }
    }
}
