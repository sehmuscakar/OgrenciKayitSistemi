using Entities.Models;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Entities.DataTransferObjects;

namespace DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {
       IList<StudentModel> GetAllStudents(Expression<Func<StudentModel, bool>> filter = null);
    }
}
