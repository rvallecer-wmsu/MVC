using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSop.Dal
{
    public class User
    {
        public Guid Id { get; set; }
        public string Firstname{ get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
