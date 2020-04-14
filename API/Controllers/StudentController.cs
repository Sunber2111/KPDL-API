using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Students;
using Application.Students.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class StudentController : BaseController
    {
        [HttpGet("subject/{idSubject}")]
        public async Task<ActionResult<List<StudentDTO>>> List(Guid idSubject)
        {
            return await Mediator.Send(new DetailBySubject.Query { IdSubject = idSubject });
        }

    }
}