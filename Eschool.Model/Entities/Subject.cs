using System;
using System.Collections.Generic;
using System.Text;

namespace Eschool.Model.Entities
{
    public class Subject : IEntityBase
    {

        public Subject()
        {
            enrollment = new List<Enrollment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Enrollment> enrollment { get; set; }
    }
}
