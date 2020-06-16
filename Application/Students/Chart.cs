using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Algorithm.KMean;
using Application.PoinTests.DTO;
using Application.Students.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class Chart
    {
        public class Query : IRequest<List<TrainingData>>
        {
            public int IdSubject { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<TrainingData>>
        {
            private readonly DataContext db;
            private readonly IMapper _mapper;

            private KMean kMean;
            
            public Handler(DataContext db, IMapper mapper)
            {
                _mapper = mapper;
                this.db = db;
            }

            public async Task<List<TrainingData>> Handle(Query request, CancellationToken cancellationToken)
            {
                var points = await db.PointTests.Where(t=>t.ClassRoomId==request.IdSubject).ToListAsync();
                var listdata = new List<Data>();
                var data = new Data();
                double value = 0;
                foreach(var p in points)
                {
                    value = (((double)p.Tk * 0.2+(double)p.Gk * 0.3+(double)p.Ck * 0.5)*2
                    +(double)p.Th)/3 ;

                    value = Math.Round(value,2,MidpointRounding.AwayFromZero);

                    var studentDTO = _mapper.Map<Student,StudentDTO>(p.Student);

                    studentDTO.Point = _mapper.Map<PointTest,PointTestDTO>(p);

                    data = new Data(){
                        Student = studentDTO,
                        Value= value
                    };
                    listdata.Add(data);
                }
                kMean = new KMean(listdata,4);
                kMean.Run();
                return kMean.TrainingDatas;
            }
        }
    }
}