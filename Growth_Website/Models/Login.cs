using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testing2.Models
{
    public class Login
    {
        [Key]
        public string? LoginUserName { get; set; }
        public string? LoginUserEmail { get; set; }
        public string? LoginPassword { get; set; }
        public bool? Isavailable { get; set; }
        public int id { get; set; }
    }
}
