using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {

        private readonly ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public void Add(Teacher t)
        {
          
            _teacherDal.Add(t);
        }

        public void Delete(Teacher t)
        {
           _teacherDal.Delete(t);   
        }

        public Teacher GetByID(int id)
        {
            Expression<Func<Teacher, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _teacherDal.Get(filter);
        }

        public IList<Teacher> GetList()
        {
            return _teacherDal.GetActiveList();
        }

        public void Update(Teacher t)
        {
            _teacherDal.Update(t);   
        }
    }
}
