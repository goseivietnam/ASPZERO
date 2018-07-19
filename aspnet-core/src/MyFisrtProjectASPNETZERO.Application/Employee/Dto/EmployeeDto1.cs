using System;
using System.Collections.Generic;
using System.Text;

namespace MyFisrtProjectASPNETZERO.Employee.Dto
{
    public class EmployeeDto1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreationTime { get; set; }
        public int PendingTask { get; set; }
        public int CompletedTask { get; set; }

    }
}
