using System;
using System.Collections.Generic;
using System.Text;

namespace Eschool.Model.Entities
{
   public class Enrollment : IEntityBase
    {
        public int Id { get; set; }
        public int Studentid { get; set; }
        public int Subjectid { get; set; }
        public virtual Student students { get; set; }
        public virtual Subject subjects { get; set; }
    }
}
