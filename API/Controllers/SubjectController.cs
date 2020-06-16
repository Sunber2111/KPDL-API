using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Semesters.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Semesters;
using Application.Subjects.DTO;
using Application.Subjects;
using Application.ClassRooms;
using Application.ClassRooms.DTO;

namespace API.Controllers
{
    public class SubjectController : BaseController
    {
        [HttpGet("semester")]
        public async Task<ActionResult<List<SemesterDTO>>> ListSemester()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SubjectDTO>>> ListSubject(int id)
        {
            return await Mediator.Send(new ListSubject.Query { SemesterId = id });
        }

        [HttpPost("classroom")]
        public async Task<ActionResult<List<ClassRoomDTO>>> List(ListCR.Query query)
        {
            return await Mediator.Send(query);
        }

    }
}