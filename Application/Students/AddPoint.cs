using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.validations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class AddPoint
    {
        public class Command : IRequest
        {
            public Guid IdPoint { get; set; }

            public double Point { get; set; }

            public int TypePoint { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext db;

            public Handler(DataContext db)
            {
                this.db = db;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                
                if(!request.TypePoint.CheckTypePoint())
                    throw new RestException(HttpStatusCode.BadRequest,new {TypePoint = "Wrong type"});

                if(!request.Point.CheckPointTest())
                    throw new RestException(HttpStatusCode.BadRequest,new {Point = "Wrong point"});

                var point = await db.PointTest.SingleOrDefaultAsync(p => p.Id == request.IdPoint);

                if (point == null)
                    throw new RestException(HttpStatusCode.NotFound, new { point = "Not Found" });
                
                switch (request.TypePoint)
                {
                    case 1:
                    {
                        point.Tk = request.Point;
                        break;
                    }
                    case 2:
                    {
                        point.Gk = request.Point;
                        break;
                    }
                    case 3:
                    {
                        point.Ck = request.Point;
                        break;
                    }
                    default:
                    {    
                        point.Th = request.Point;
                        break;
                    }

                }

                var success = await db.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Has An Error Oscur");
            }
        }
    }
}