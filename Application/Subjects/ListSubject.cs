using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Subjects.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Subjects
{
    public class ListSubject
    {
        public class Query : IRequest<List<SubjectDTO>>
        {
            public int SemesterId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<SubjectDTO>>
        {
            private readonly DataContext _db;
            private readonly IMapper _mapper;

            public Handler(DataContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<List<SubjectDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ds = await (from c in _db.Subjects
                                where c.ClassRooms.Any(x => x.SemesterId == request.SemesterId)
                                select c).ToListAsync();

                return _mapper.Map<List<Subject>, List<SubjectDTO>>(ds);
            }
        }
    }
}