using System;
using System.Collections.Generic;

namespace Domain
{
    public  class Account
    {
        public string NameLogin { get; set; }
        public string Password { get; set; }
        public int? IdTeacher { get; set; }
        public bool? IsEnable { get; set; }
    }
}
