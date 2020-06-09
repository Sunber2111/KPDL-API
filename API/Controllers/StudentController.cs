using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.AI;
using Application.Algorithm.FPGrowth;
using Application.Algorithm.KMean;
using Application.Students;
using Application.Students.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class StudentController : BaseController
    {
        [HttpGet("subject/{idSubject}")]
        public async Task<ActionResult<List<StudentDTO>>> List(int idSubject)
        {
            return await Mediator.Send(new DetailBySubject.Query { IdSubject = idSubject });
        }

        [HttpPost("point")]
        public async Task<ActionResult<Unit>> Update(AddPoint.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("chart/{idSubject}")]
        public async Task<ActionResult<List<TrainingData>>> Chart(int idSubject)
        {
            return await Mediator.Send(new Chart.Query{ IdSubject = idSubject });
        }
        [HttpGet("fpg")]
        public async Task<List<List<string>>> Fpg()
        {
            return await Mediator.Send(new FPGrowth.Query());
        }
    }
}