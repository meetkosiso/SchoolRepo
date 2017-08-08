using System;
using System.Collections.Generic;
using System.Text;

namespace Eschool.Model.Entities
{
    public class Student : IEntityBase
    {
        public Student()
        {
            enrollment = new List<Enrollment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentPhone { get; set; }

        public int Classid { get; set; }

        public virtual Classes classes { get; set; }
        public virtual ICollection<Enrollment> enrollment { get; set; }
    }
}
