using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eschool.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            enrollment = new List<EnrollmentViewModel>();
        }
        public string Studentid { get; set; }
        public string Name { get; set; }
        public string ParentPhone { get; set; }

        public int ClassName { get; set; }
       public virtual ICollection<EnrollmentViewModel> enrollment { get; set; }
    }
}
