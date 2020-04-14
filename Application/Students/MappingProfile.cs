using System.Linq;
using Application.PoinTests.DTO;
using Application.Students.DTO;
using AutoMapper;
using Domain;

namespace Application.Students
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                    .ForMember(d => d.Point, o => o.MapFrom(s => s.PointTest.FirstOrDefault()));
            CreateMap<PointTest, PointTestDTO>();
        }
    }
}