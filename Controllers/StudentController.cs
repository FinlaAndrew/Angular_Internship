//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using dotnetcoretraining.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Web.Models;

//namespace dotnetcoretraining.Controllers
//{
//    [Route("student")]
   
//    public class StudentController : ControllerBase
//    {
//        private readonly DatabaseContext _dbContext;
//        public StudentController(DatabaseContext dbContext)
//        {
//            this._dbContext = dbContext;
//        }
//        [HttpPost("save")]
//        public async Task<IActionResult> Save([FromBody] StudentViewModel model)
//        {
//            var saveData = new Stud()
//            {
//                Name = model.Name,
//                Mobile = model.Mobile,
//                Gender = model.Gender,
//              // Country = model.Contry,
//               // DOB = model.Dob,
//               // IsIndian = model.Isindian


//            };
//            await _dbContext.Studs.AddAsync(saveData);
//            await _dbContext.SaveChangesAsync();
//            return Ok(saveData);



//        }
//        [HttpGet("getData")]
//        public async Task<IActionResult> GetData()
//        {

//            var items = await _dbContext.Studs

//              .ToListAsync();
//            return Ok(items);
//        }
//        [HttpDelete("deletestudent/{id}")]
//        public async Task<IActionResult> DeleteStudent(int id)
//        {


//            var studdet = await _dbContext.Studs
//                .Where(s => s.Id == id)
//                .SingleOrDefaultAsync();
//            _dbContext.Studs.Remove(studdet);
//            await _dbContext.SaveChangesAsync();
//            return Ok(studdet);


//        }

//    }
//    public class StudentViewModel
//    {
//        public string Name { get; set; }
//        public string Mobile { get; set; }
//        public string Gender { get; set; }
//        public bool Isindian { get; set; }
//         // public bool Indian { get; set; }

//        public string Contry { get; set; }
//        public DateTime Dob { get; set; }


//    }
   
//}
