using System;
using System.Collections.Generic;
using System.Text;
using Eschool.Model.Entities;

namespace Eschool.Data.Abstract
{
   public interface IStudentRepository : IEntityBaseRepositories<Student> { }

   public interface IClassesRepository : IEntityBaseRepositories<Classes> { }

   public interface ISubjectRepository : IEntityBaseRepositories<Subject> { }

   public interface IEnrollmentRepository : IEntityBaseRepositories<Enrollment> { }
}
