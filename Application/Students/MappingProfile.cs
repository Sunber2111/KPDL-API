using System.Linq;
using Application.ClassRooms.DTO;
using Application.PoinTests.DTO;
using Application.Semesters.DTO;
using Application.Students.DTO;
using Application.Subjects.DTO;
using AutoMapper;
using Domain;

namespace Application.Students
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>();

            CreateMap<Subject, SubjectDTO>();

            CreateMap<ClassRoom, ClassRoomDTO>();

            CreateMap<Semester, SemesterDTO>();

            CreateMap<PointTest, PointTestDTO>();
        }
    }
}