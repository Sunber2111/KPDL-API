using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Students.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class List
    {
        public class Query : IRequest<List<StudentDTO>>
        {

        }

        public class Handler : IRequestHandler<Query, List<StudentDTO>>
        {
            private readonly DataContext _db;
            private readonly IMapper _mapper;

            public Handler(DataContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<List<StudentDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _db.Student.ToListAsync();
                return _mapper.Map<List<Student>,List<StudentDTO>>(students);
            }
        }
    }
}