using System;
using System.Collections.Generic;
using System.Text;
using Eschool.Data.Abstract;
using Eschool.Model.Entities;

namespace Eschool.Data.Repositories
{
   public class EnrollmentRepository : EntityBaseRepositories<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(EschoolContext eschoolcontext) : base(eschoolcontext) { }
    }
}
