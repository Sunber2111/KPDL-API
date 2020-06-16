using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.ClassRooms.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ClassRooms
{
    public class ListCR
    {
        public class Query : IRequest<List<ClassRoomDTO>>
        {
            public int SubjectId { get; set; }

            public int SemesterId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<ClassRoomDTO>>
        {
            private readonly DataContext _db;
            private readonly IMapper _mapper;

            public Handler(DataContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<List<ClassRoomDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ds = await _db.ClassRooms.Where(x=>x.SemesterId == request.SemesterId && x.SubjectId == request.SubjectId).ToListAsync();
                return _mapper.Map<List<ClassRoom>, List<ClassRoomDTO>>(ds);
            }
        }
    }
}