using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskManagmentSystem_TMS_.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicPath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ProfilePicture { get; set; }
        public string Department { get; set; }
        public string phoneNo { get; set; }
        
        //Navigational properties
            //Collection Navigation Property:
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}