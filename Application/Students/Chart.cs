using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Algorithm.KMean;
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
            public Guid IdSubject { get; set; }
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
                var students = await db.Student
                                        .Where(student => student.PointTest.Any(x => x.IdSubject == request.IdSubject)).ToListAsync();
                var listdata = new List<Data>();
                var data = new Data();
                double value = 0;
                var ds =_mapper.Map<List<Student>, List<StudentDTO>>(students);
                foreach(var student in ds)
                {
                    value = (((double)student.Point.Tk * 0.2+(double)student.Point.Gk * 0.3+(double)student.Point.Ck * 0.5)*2
                    +(double)student.Point.Th)/3 ;
                    data = new Data(){
                        Student = student,
                        Value= value
                    };
                    listdata.Add(data);
                }
                kMean = new KMean(listdata,2);
                kMean.Run();
                return kMean.TrainingDatas;
            }
        }
    }
}