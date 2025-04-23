using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class StudentDal : EfEntityRepositoryBase<Student, ProjeContext>, IStudentDal
    {
        public IList<StudentModel> GetAllStudents(Expression<Func<StudentModel, bool>> filter = null)
        {
            using (var context = new ProjeContext())
            {
                var query = context.Students
                    //.Where(student => student.AktifMi) // Sadece aktif öğrencileri getir
                    .Select(student => new StudentModel
                    {
                        Id = student.Id,
                        Ad = student.Ad,
                        Soyad = student.Soyad,
                        Image = student.Image,
                        DogumTarihi = student.DogumTarihi,
                        Cinsiyet = student.Cinsiyet,
                        Sinif = student.Sinif,
                        TeacherFullName = student.Teacher.Ad + " " + student.Teacher.Soyad
                    });

                return filter != null ? query.Where(filter).ToList() : query.ToList();
            }
        }
    }
}
