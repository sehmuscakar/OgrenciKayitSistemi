using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Teacher:BaseEntity
    {
     
        public byte Brans { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
