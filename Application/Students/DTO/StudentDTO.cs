using System;
using System.Collections.Generic;
using Application.PoinTests.DTO;

namespace Application.Students.DTO
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public PointTestDTO Point { get; set; }
    }
}