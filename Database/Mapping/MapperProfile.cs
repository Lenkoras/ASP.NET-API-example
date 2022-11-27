using AutoMapper;
using Database.Models;
using Shared.Enums;
using Shared.Models;

namespace Database.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IdentifierDocument, DocumentFull>();

            CreateMap<Employee, EmployeeShort>()
                .ForMember(edto => edto.FullName, opt => opt.MapFrom(employee => Employee.FullName(employee)));
            CreateMap<Employee, EmployeeFull>();

            CreateMap<Department, DepartmentShort>();
            CreateMap<Department, DepartmentShortWithGroupFlag>()
                .ForMember(edto => edto.IsGroup, opt => opt.MapFrom(src => src.Type == DepartmentType.Group));

            CreateMap<Education, EducationShort>();
            CreateMap<Education, EducationFull>();

            CreateMap<Relative, RelativeFull>();
            CreateMap<Relationship, RelationshipFull>();

            CreateMap<Workplace, WorkplaceFull>();

            CreateMap<RankAssignment, RankAssignmentFull>();
            CreateMap<PositionAssignment, PositionAssignmentFull>();
        }
    }
}
