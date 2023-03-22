
using dotnetcoretraining.Model;
using dotnetcoretraining.Models;
using dotnetcoretraining.Service.Finla;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnetcoretraining.Controllers
{
    [Route("mark")]
    public class Marksubjectcontroller : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly Subjectmarkservice _service;
        //private object lblAge;
        //private object _service;

        public Marksubjectcontroller(DatabaseContext dbContext, Subjectmarkservice service)
        {
            this._dbContext = dbContext;
            this._service = service;
        }
        [HttpPost("postsave/{id}")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Postsave(Guid id,[FromBody] marsubViewModels model)
        {
            var Subjectmarklist = new List<SubjectViewModels>();
            var CourseId = HttpContext.Request.Query["subject"].ToString();

            // // var items = _dbContext.students.Select(s => new SubjectViewModels()
            Subjectmarklist = _dbContext.students.Select(s => new SubjectViewModels()
             {
             StudentsId = s.StudentId.ToString(),
              Studentname = s.FirstName
             //Marks = null,
             //SecMark = null,
             //ThirdMark = null,
             //TotalMark = null
             }).ToList();
             var sub = _dbContext.marsub.Where(s=>s.SubjectsId==id).Select(s => new MarkViewModels()
              {
                SubjectsId = s.SubjectsId.ToString(),
                StudentsId = s.StudentsId.ToString(),
                Subjectname =s.Subjects.SubjectName,
                Marks = s.Marks.ToString(),
                ThirdMark = s.Thirdmark.ToString(),
                TotalMark = s.Total,
                Percentage = s.Percentage
             }).ToList();
             var subject = _dbContext.subjects.ToList();
             var Studentmarklist = new List<MarkViewModels>();

            if (sub.Any())
            {
                var studentId = Subjectmarklist.Select(s => s.StudentsId).ToList();
                await Deleterows(studentId, id, "save");
            }
            foreach (var me in Subjectmarklist)
            {
                Studentmarklist = new List<MarkViewModels>();
                var mark = model.StudentMEDet.Where(s => s.StudentsId == me.StudentsId).FirstOrDefault();
               
                  if (mark.Marks != null || mark.ThirdMark != null)
                  {
                    //if (sub.Any())
                     //{
                      // var studentId = Subjectmarklist.Select(s => s.StudentsId).ToList();
                      //await Deleterows(studentId,id, "save");
                        var sk = new Mark()
                        {
                            StudentsId = Guid.Parse(mark.StudentsId),
                            Marks = decimal.Parse(mark.Marks),
                            SubjectsId = Guid.Parse(mark.SubjectsId),
                            Thirdmark = Decimal.Parse(mark.ThirdMark),
                            Total = mark.TotalMark,
                            Percentage = mark.Percentage
                        };
                        await _dbContext.marsub.AddAsync(sk);
                        await _dbContext.SaveChangesAsync();
                    //}
                            //else
                             // {
                               // var sk = new Mark()
                               // {
                                 //  StudentsId = Guid.Parse(mark .StudentsId),
                                 //  Marks =decimal.Parse(mark .Marks),
                                 // SubjectsId =Guid.Parse( mark.SubjectsId),
                                 // Thirdmark =Decimal.Parse( mark.ThirdMark),
                                 //Total=mark.TotalMark
                               //};
                              //await _dbContext.marsub.AddAsync(sk);
                              // await _dbContext.SaveChangesAsync();

                           // }
                  }
                             
                             }

                            return Ok();
        }

        public async Task<IActionResult> Deleterows(List<string> studentid,Guid id, string type)
        {
            var mark = _dbContext.marsub.Where(s => studentid.Contains(s.StudentsId.ToString())&& s.SubjectsId==id).ToList();
            if (type == "delete")
            {
                if (mark.Any())
                {
                    _dbContext.marsub.RemoveRange(mark);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("no data to delete");
                }
            }
            else
            {
                if (mark.Any())
                {
                    _dbContext.marsub.RemoveRange(mark);
                    await _dbContext.SaveChangesAsync();
                }
            }
            return Ok();
        }
        [HttpGet("getSub")]
        public async Task<IActionResult> GetSubjects()
        {

            var items = await _service.GetSubjects();

            return Ok(items);
        }

        [HttpGet("getStud/{id}")]
        public IActionResult GetStudent(Guid id)
        {
            var Subjectmarklist = new List<SubjectViewModels>();
            var items = _dbContext.students.Select(s => new SubjectViewModels()
            {
                StudentsId = s.StudentId.ToString(),
                Studentname = s.FirstName,
                Marks = null,
                //SecMark = null,
                ThirdMark = null,
                TotalMark = 0,
                Percentage =0

            }).ToList();
            //Subjectmarklist.Add(items);
            var sub = _dbContext.marsub.Where(s=>s.SubjectsId==id).Select(s => new MarkViewModels()
            {
                SubjectsId = s.SubjectsId.ToString(),
                StudentsId = s.StudentsId.ToString(),
                Studentname = s.Students.FirstName,
                Subjectname =s.Subjects.SubjectName,
                Marks = s.Marks.ToString(),
                ThirdMark=s.Thirdmark.ToString(),
                TotalMark = s.Total,
                Percentage = s.Percentage
            }).ToList();
            var subject = _dbContext.subjects.ToList();
            var Studentmarklist = new List<MarkViewModels>();
            foreach (var item in items)
            {
                //Studentmarklist = new List<MarkViewModels>();
               // foreach (var subjectdet in subject)
                //{
                   //if (sub.Any())
                   // {
                        var marks = sub.Where(s => s.StudentsId == item.StudentsId&& s.SubjectsId ==id.ToString()).FirstOrDefault();
                        if (marks != null)
                        {
                            var submark = new MarkViewModels()
                            {
                                SubjectsId = marks.SubjectsId,
                                StudentsId=marks.StudentsId,
                                Studentname = marks.Studentname,
                                Subjectname = marks.Subjectname,
                                Marks =marks.Marks,
                                ThirdMark =marks.ThirdMark,
                                TotalMark = marks.TotalMark,
                                Percentage = marks.Percentage
                            };
                            Studentmarklist.Add(submark);
                        }
                    else
                    {
                        var submark = new MarkViewModels
                        {
                            SubjectsId = id.ToString(),
                            Studentname = item.Studentname,
                            StudentsId = item.StudentsId,
                            //Subjectname = marks.SubjectName,
                            Marks = null,
                            ThirdMark = null,
                            TotalMark = 0,
                            Percentage = 0
                        };
                        Studentmarklist.Add(submark);
                    }

               // }
                    
            }

            return Ok(Studentmarklist);
        }
            

           
    
    [HttpGet("geteditMark/{id}")]

    public async Task<IActionResult> Geteditmark(Guid id)
    {
        var data = await _dbContext.marsubs.Where(s => s.Id == id).Select(s => new SMViewModels()
        {
            StudentsId = s.StudentsId,
            Marks = s.Marks,
            //SecMark = s.SecMark,
            ThirdMark = s.ThirdMark,
            TotalMark = Convert.ToString(s.TotalMark)
   
        }).ToListAsync();
        return Ok(data);
    }
    [HttpPatch("updateMark")]
    public async Task<IActionResult> UpdateMarks([FromBody] marsubViewModels model)
    {

        var Studentmarklist = new List<SMViewModels>();
       
        return Ok();
    }
    [HttpPost("deleteMark/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteMark(Guid id, [FromBody] marsubViewModels model)
    {
        try
        {
            var studentId = model.StudentMEDet.Select(s => s.StudentsId).ToList();
            await Deleterows(studentId, id, "delete");

            return Ok();
        }
        catch (Exception e)
        {
            return UnprocessableEntity(e);
        }
    }

    public class SubjectViewModels
    {

        public string StudentsId { get; set; }
        public string Studentname { get; set; }
            public string SubjectsId { get; set; }
            public string Subjectname { get; set; }
            public string Marks { get; set; }
        //public string SecMark { get; set; }
        public string ThirdMark { get; set; }
        public decimal TotalMark { get; set; }
            public decimal Percentage { get; set; }
        //public List<MarkViewModels> Mark { get; set; }

    }
    public class MarkViewModels
    {
        public string SubjectsId { get; set; }
        public string StudentsId { get; set; }
            public string Studentname { get; set; }
            public string Subjectname { get; set; }
        public string Marks { get; set; }
            public string ThirdMark { get; set; }
            public decimal? TotalMark { get; set; }
            public decimal Percentage { get; set; }


        }
    public class SMViewModels
    {
        public Guid StudentsId { get; set; }
        public string Studentname { get; set; }
        public string Marks { get; set; }
       // public string SecMark { get; set; }
        public string ThirdMark { get; set; }
        public string TotalMark { get; set; }
        public decimal Percentage { get; set; }
        }
    public class marsubViewModels
    {
        public List<SubjectViewModels> StudentMEDet
            { get; set; }
    }
        public class SubjectIdViewModels
        {
            public string Subject { get; set; }
        }
}
}
