using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagmentSystem_TMS_.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase ProfilePicture { get; set; }
        public string Department { get; set; }  
        public string phoneNo { get; set; }

    }
}