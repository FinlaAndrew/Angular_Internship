using dotnetcoretraining.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Service.Finla
{
    public class allstudentsservice
    {
        private readonly DatabaseContext _dbContext;
        public allstudentsservice(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public async Task<List<allsubjectsViewModels>> getallsub()
        {
            var studentdata = _dbContext.marsub.AsQueryable();

            var items = _dbContext.marsub.Select(s => new stusubjectsViewModels()
            {
                StudentId = s.StudentsId,
                Studentname = s.Students.FirstName,
                
            }).Distinct().ToList();
            var studentmarklist = new List<allsubjectsViewModels>();
            //var marklist = new List<allmarksViewModels>();
            foreach (var item in items)
            {
                var marklist = new List<allmarksViewModels>();
                var data =  studentdata.Where(s => s.StudentsId == item.StudentId).ToList();
                var total = data.Sum(s => s.Total);
                var percentage = (total / 30) * 100;
                foreach (var datas in data)
                {
                    var subjectname = _dbContext.subjects.Where(s => s.SubjectId == datas.SubjectsId).Select(s=>s.SubjectName).FirstOrDefault();
                    var subdetail = new allmarksViewModels
                    {
                        subject = subjectname,
                        mark = datas.Marks+datas.Thirdmark,
                        
                    };
                    marklist.Add(subdetail);
                }
                var mark = new allsubjectsViewModels
                {
                    StudentId = item.StudentId,
                    Studentname = item.Studentname,
                    Marks = marklist,
                    Percentage = percentage
                };
                studentmarklist.Add(mark);


            }
            studentmarklist = studentmarklist.OrderBy(s => s.Studentname).ToList();
            return studentmarklist;
        }
    }
    public class allsubjectsViewModels
    {
        public Guid StudentId { get; set; }
        public string Studentname { get; set; }
        public decimal Percentage { get; set; }
        public List<allmarksViewModels> Marks { get; set; }

    }
    public class allmarksViewModels
    {
        public string subject { get; set; }
        public decimal mark { get; set; }
        public decimal Physics { get; set; }
        public decimal Chemistry { get; set; }
        public decimal Mathematics { get; set; }
        
    }
}
