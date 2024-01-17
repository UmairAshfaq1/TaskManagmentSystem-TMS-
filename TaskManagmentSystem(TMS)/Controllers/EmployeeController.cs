using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagmentSystem_TMS_.Models;

namespace TaskManagmentSystem_TMS_.Controllers
{
    public class EmployeeController : Controller
    {

        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult CreateEmployee(Employee employee)
        {
            //HttpPostedFileBase pb = Request.Files["ProfilePicture"];

            Employee employee1 = new Employee();
            
            var ProfileImage = employee.ProfilePicture;

            if((ProfileImage.FileName != null) && (ProfileImage.ContentLength > 0))
            {
                string ProfileImgExtention = Path.GetExtension(ProfileImage.FileName);
                string[] allowedExtention = { ".jpg", ".png", ".jpeg", ".svg" };



                //if (!allowedExtention.Contains(ProfileImgExtention))
                //{
                //    ModelState.AddModelError("ProfilePicture", "Invalid file format. Please upload a valid image file.");
                //    return View(model);
                //}
                 
                //code Should be like that which is mentioned above but as I have done it already so no need to change just keep in mind
                if (allowedExtention.Contains(ProfileImgExtention))
                {
                    var maxfilesize = 5 * 1024 * 1024; // 5 MB
                    if(ProfileImage.ContentLength > maxfilesize)
                    {
                        ModelState.AddModelError("ProfilePicture", "File size exceeds the maximum limit of 5MB.");
                        return View(employee);
                    }

                    string fileName = Path.GetFileName(ProfileImage.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Images"),fileName);


                    try
                    {
                        employee1.ProfilePicture.SaveAs(path);

                        employee1.ProfilePicPath = path;
                        employee1.Name = employee.Name;
                        employee1.Department = employee.Department;
                        employee1.phoneNo = employee.phoneNo;

                        _context.employees.Add(employee1);
                        _context.SaveChanges();
                    }catch(Exception ex)
                    {
                        ModelState.AddModelError("ProfilePicture", $"Error uploading file: {ex.Message}");
                        return View(employee);
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}