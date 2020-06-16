using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Semesters.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Semesters
{
    public class List
    {
        public class Query : IRequest<List<SemesterDTO>>
        {

        }

        public class Handler : IRequestHandler<Query, List<SemesterDTO>>
        {
            private readonly DataContext _db;
            private readonly IMapper _mapper;

            public Handler(DataContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<List<SemesterDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ds = await _db.Semesters.ToListAsync();
                return _mapper.Map<List<Semester>, List<SemesterDTO>>(ds);
            }
        }
    }
}