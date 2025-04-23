using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService:IGenericService<Student>
    {
        IList<StudentModel> GetAllStudents(Expression<Func<StudentModel, bool>> filter = null);
    }
}
