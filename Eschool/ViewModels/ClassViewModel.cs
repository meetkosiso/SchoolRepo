using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eschool.ViewModels
{
    public class ClassViewModel
    {
        public ClassViewModel()
        {
            students = new List<StudentViewModel>();
        }

        public int Classid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentViewModel> students { get; set; }
    }
}
