using System;
using System.Collections.Generic;
using System.Text;
using Eschool.Data.Abstract;
using Eschool.Model.Entities;

namespace Eschool.Data.Repositories
{
    public class StudentRepository : EntityBaseRepositories<Student>, IStudentRepository
    {
        public StudentRepository(EschoolContext eschoolcontext) : base(eschoolcontext) { }
    }
}
