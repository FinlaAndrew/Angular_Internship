using dotnetcoretraining.Model;
using dotnetcoretraining.Service.Finla;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static dotnetcoretraining.Controllers.studentdetailscontroller;

namespace dotnetcoretraining.Controllers
{
    [Route("studentreport")]
    public class Studentreportcontroller : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly Studentreportservice _service;
       // private object lblAge;

        public Studentreportcontroller(DatabaseContext dbContext, Studentreportservice service)
        {
            this._dbContext = dbContext;
            this._service = service;
        }

        [HttpGet("getcountryreport")]
        public async Task<IActionResult> getCountry()
        {

            var items = await _service.getCountry();

        return Ok(items);
        }
        //[HttpPost("countrysview")]
       // public async Task<IActionResult> View([FromBody] StudentsViewModels model)
        //{
        //    return Ok();
       // }

        [HttpGet("countryview")]
        public async Task<IActionResult> Save()
        {
            var countryid = HttpContext.Request.Query["country"].ToString();
            var IncludeStudents = HttpContext.Request.Query["gender"].ToString();
            var age = HttpContext.Request.Query["age"].ToString();
            var SectionId = HttpContext.Request.Query["radage"].ToString();
            var studentdata = _dbContext.students.AsQueryable();
            //int years = DateTime.Now.Year - age.Value.Year;

            //if (dateTimePicker.Value.AddYears(years) > DateTime.Now) years--;

            DateTime n = DateTime.Now;
            n =n.AddYears(-int.Parse(age));
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            n = n.AddMonths(-month + 1);
            n = n.AddDays(-day + 1);
            //var shortDate = n.ToShortDateString();
            // var date = n.Year - int.Parse(age);
            // DateTime.n.ToString("M/d/yyyy");
            // DateTime.Today.ToString("dd-MM-yyyy");

            //DateTime dt = DateTime.Parse(int.Parse(date));
            //int date = n.Year - int.Parse(age);
            if (SectionId == "0")
            {
                studentdata = studentdata.Where(s => s.Dob.Value.Year < n.Year);
            }
            else if (SectionId == "1")
            {
                studentdata = studentdata.Where(s => s.Dob.Value.Year > n.Year);
            }
           else 
           {
               studentdata = studentdata.Where(s => s.Dob.Value.Year == n.Year);
           }
        
        
                var data = studentdata.Where(s => s.CountrysId == Guid.Parse(countryid) && s.Gender== IncludeStudents).Select(s => new StudentViewModels()
            {
                StudentId = s.StudentId,
                Firstname = s.FirstName,
                Lastname = s.LastName,
                Email = s.Email,
                Dob = DateFormat(s.Dob).ToString(),
                Age = s.Age,
                Gender = s.Gender,
                Mobno = s.Mobilenumber,
                Place = s.Place,
                Country = s.Countrys.Name,
                Indian = s.IsIndian
            }).ToList();

            
            return Ok(data);
        }
       // public int getYear(string str)
        //{
           // return (int)Regex.Match(int.Parse(str), d{4}.Value));
       // }

        public static string DateFormat(DateTime? formatDate)
        {
            return $"{formatDate:yyyy'-'MM'-'dd}";
        }
    }
}
