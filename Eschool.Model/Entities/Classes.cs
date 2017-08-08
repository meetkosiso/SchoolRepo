using System;
using System.Collections.Generic;
using System.Text;

namespace Eschool.Model.Entities
{
   public class Classes : IEntityBase
    {
        public Classes()
        {
            students = new List<Student>();
        }
        public int Id{ get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> students { get; set; }
    }
}
