using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DetailBySubject
    {
        public class Query : IRequest<List<StudentDTO>>
        {
            public int IdSubject { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<StudentDTO>>
        {
            private readonly DataContext db;
            private readonly IMapper _mapper;

            public Handler(DataContext db, IMapper mapper)
            {
                _mapper = mapper;
                this.db = db;
            }

            public async Task<List<StudentDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await db.Students
                                        .Where(student => student.PointTest.Any(x => x.IdSubject == request.IdSubject)).ToListAsync();
                return _mapper.Map<List<Student>, List<StudentDTO>>(students);
            }
        }
    }
}