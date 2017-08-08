using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eschool.ViewModels
{
    public class SubjectViewModel
    {
        public SubjectViewModel()
        {
            enrollment = new List<EnrollmentViewModel>();
        }
        public int Subjectid { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EnrollmentViewModel> enrollment { get; set; }
    }
}
