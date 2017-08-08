using System;
using System.Collections.Generic;
using System.Text;
using Eschool.Data.Abstract;
using Eschool.Model.Entities;

namespace Eschool.Data.Repositories
{
   public class ClassRepository : EntityBaseRepositories<Classes>, IClassesRepository
    {
         public ClassRepository(EschoolContext eschoolcontext) : base(eschoolcontext) { }
    }
}
