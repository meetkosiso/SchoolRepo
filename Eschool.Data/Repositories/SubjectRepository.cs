using System;
using System.Collections.Generic;
using System.Text;
using Eschool.Data.Abstract;
using Eschool.Model.Entities;

namespace Eschool.Data.Repositories
{
   public class SubjectRepository : EntityBaseRepositories<Subject>, ISubjectRepository
    {
        public SubjectRepository(EschoolContext eschoolcontext) : base(eschoolcontext) { }
    }
}
