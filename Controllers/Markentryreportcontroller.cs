using dotnetcoretraining.Model;
using dotnetcoretraining.Service.Finla;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static dotnetcoretraining.Controllers.Markentryreportcontroller;

namespace dotnetcoretraining.Controllers
{
    [Route("markentryreport")]
    public class Markentryreportcontroller : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly Markentryreportservice _service;

        public Markentryreportcontroller(DatabaseContext dbContext, Markentryreportservice service)
        {
            this._dbContext = dbContext;
            this._service = service;
        }
        [HttpGet("getstureport")]
        public async Task<IActionResult> getStusub()
        {
            var items = await _service.getStusub();

            return Ok(items);
        }
        [HttpGet("stuview")]
        public async Task<IActionResult> View()
        {
         var studentid = HttpContext.Request.Query["student"].ToString();
         var studentdata = _dbContext.marsub.AsQueryable();
            var subject = _dbContext.subjects.ToList();
            var physics = 0;
            var chemistry = 0;
            var maths = 0;
            var marklist = new List<MarkViewModels>();
            foreach (var item in subject)
            {
                var data = await studentdata.Where(s => s.StudentsId == Guid.Parse(studentid) ).ToListAsync();
                var markdetail = data.Where(s => s.SubjectsId == item.SubjectId).FirstOrDefault();
                var subdetail = new MarkViewModels
                {
                    subject = item.SubjectName,
                    mark = (markdetail.Marks) + (markdetail.Thirdmark)
                };
                marklist.Add(subdetail);
               
                //{
                //Physics = (s.Marks) + (s.Thirdmark),
                //Chemistry = s.Marks + s.Thirdmark,
                //Mathematics = s.Marks + s.Thirdmark,
                //Percentage = s.Percentage
                //});
                // physics =Convert.ToInt32 (data.Marks + data.Thirdmark);
            }
            var total = marklist.Sum(s => s.mark);
            var percentage = (total / 30) * 100;
            
            var mark = 0;
            dynamic model = new ExpandoObject();
            model.marklist =marklist;
            model.percentage = percentage;
           // model.ShowConcession = showConcessionColumn;
           // model.UploadedDate = UploadedDate;
            return Ok(model);
        }
        public class subjectsViewModels
        {
            public decimal Physics { get; set; }
            public decimal Chemistry { get; set; }
            public decimal Mathematics { get; set; }
            public decimal Percentage { get; set; }
          
        }
        public class MarkViewModels
        {
            public string subject { get; set; }
            public decimal mark { get; set; }
        }
    }
}

