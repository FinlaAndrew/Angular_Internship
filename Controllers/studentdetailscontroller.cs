using dotnetcoretraining.Model;
using dotnetcoretraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Controllers
{
   
    [Route("studentdata")]
    public class studentdetailscontroller : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public studentdetailscontroller(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //[HttpPost("save")]
        //public void AddstudentRecord([FromBody] StudentViewModels studentdata)
        //{
        //    //_dbContext.students.Add(studentdata);
        //    //_dbContext.SaveChanges();
        //
        [HttpGet("getstudent")]
        public IActionResult GetData()
        {
            var data = _dbContext.students.Select(s => new StudentViewModels() { 
                StudentId= s.StudentId,
                Firstname = s.FirstName,
                Lastname = s.LastName,
                Email = s.Email,
                //Dob=s.Dob.ToString(),
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
        
        

        [HttpPost("save")]
        [HttpPost]
        [AllowAnonymous]
        public async Task <IActionResult> Save([FromBody]StudentViewModels model)
        {
            var saveData = new Studentf()
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                Email = model.Email,
                Mobilenumber = model.Mobno,
                //Dob = DateTime.Parse(model.Dob),
                Dob=DateTime.Parse(model.Dob),
                Gender = model.Gender,
                IsIndian = model.Indian,
                CountrysId = Guid.Parse( model.Country),
                Place = model.Place,
                Age = model.Age
               


            };
            await _dbContext.students.AddAsync(saveData);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }
        [HttpPost("updatedata/{id}")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Updatedata( string id, [FromBody] StudentViewModels model)
        {
            var updateData = _dbContext.students.Where(s => s.StudentId == Guid.Parse(id)).FirstOrDefault();
            
                updateData.FirstName = model.Firstname;
                updateData.LastName = model.Lastname;
                updateData.Email = model.Email;
                updateData.Mobilenumber = model.Mobno;
            updateData.Dob = DateTime.Parse(model.Dob);
            //updateData.Dob = model.Dob;
             updateData.Gender = model.Gender;
                updateData.IsIndian = model.Indian;
                updateData.Country = model.Country;
                updateData.Place = model.Place;
                updateData.Age = model.Age;
            // _dbContext.Entry(flashNews).CurrentValues.SetValues(flashNews);
            // await _dbContext.students.
            //  _dbContext.students(updateData).CurrentValues.SetValues(updateData);
            _dbContext.students.Update(updateData);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("deletedata/{id}")]
        public async Task<IActionResult> Deletedata(string id)
        {
            var data =_dbContext.students.Where(s => s.StudentId == Guid.Parse(id)).FirstOrDefault();
             _dbContext.students.Remove(data);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("geteditdata/{id}")]
        
        public async Task<IActionResult> Geteditdata( string id)
        {
            var data = _dbContext.students.Where(s => s.StudentId == Guid.Parse(id)).Select(s => new StudentViewModels() {
                Firstname = s.FirstName,
                Lastname = s.LastName,
                Email = s.Email,
                //Dob=s.Dob.ToString(),
                Dob = DateFormat(s.Dob).ToString(),

                Age = s.Age,
                Gender = s.Gender,
                Mobno = s.Mobilenumber,
                Place = s.Place,
                CountryId =  s.CountrysId,
                Indian = s.IsIndian

            }).ToList();
            return Ok(data);
        }

        public static string DateFormat(DateTime? formatDate)
        {
            return $"{formatDate:yyyy'-'MM'-'dd}";
        }

        public class StudentViewModels
        {  
            public Guid StudentId { get; set; }
            public int Age { get; set; }
            public string Country { get; set; }
            public Guid CountryId { get; set; }
            public string Dob { get; set; }
            public string Email { get; set; }
            public string Firstname { get; set; }
            public string Gender { get; set; }
            public bool? Indian { get; set; }
            public string Lastname{ get; set; }
            public string Mobno{ get; set; }
            public string Place { get; set; }
            
       
           
            //public string Name { get; internal set; }
            //public DateTime DateOfBirth { get; internal set; }
            //public string Country { get; internal set; }
            //public bool IsIndian { get; internal set; }
            //public string MobileNumber { get; internal set; }
        }
    }
}


