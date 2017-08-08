using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eschool.Model.Entities;


namespace Eschool.ViewModels.Mapping
{
    public static class DomainToViewModelMappings
    {
        public static IMapperConfigurationExpression ConfigureSchoolMapping(this IMapperConfigurationExpression configureThis)
        {
            configureThis.CreateMap<Student, StudentViewModel>()
            .ForMember(x => x.ClassName, o => o.MapFrom(p => p.classes.Id));

            configureThis.CreateMap<Enrollment, EnrollmentViewModel>()
            .ForMember(x => x.StudentName, o => o.MapFrom(p => p.students.Name))
            .ForMember(x => x.SubjectTitle, o => o.MapFrom(p => p.subjects.Name));

            configureThis.CreateMap<Classes, ClassViewModel>();

            configureThis.CreateMap<Subject, SubjectViewModel>();
            // return code to path
            return configureThis;
            
        }
    }
}
