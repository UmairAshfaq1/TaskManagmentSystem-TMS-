using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagmentSystem_TMS_.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SelectedEmployeeId { get; set; }

        //Navigational properties
            //Collection Navigation Property:
        public IEnumerable<Employee> Employees { get; set; }
    }
}