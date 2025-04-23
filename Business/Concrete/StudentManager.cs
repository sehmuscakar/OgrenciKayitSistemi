using Business.Abstract;
using DataAccess.Abstract;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public void Add(Student t)
        {
            _studentDal.Add(t);
        }
        public void Delete(Student t)
        {
           _studentDal.Delete(t);
        }

        public IList<StudentModel> GetAllStudents(Expression<Func<StudentModel, bool>> filter = null)
        {
            return _studentDal.GetAllStudents(filter);
        }

        public Student GetByID(int id)
        {
            Expression<Func<Student, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _studentDal.Get(filter);
        }
        public IList<Student> GetList()
        {
            return _studentDal.GetActiveList();
        }
        public void Update(Student t)
        {
          
            _studentDal.Update(t);  
        }
    }
}
