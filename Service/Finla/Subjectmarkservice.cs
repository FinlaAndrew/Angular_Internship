using dotnetcoretraining.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Service.Finla
{
    public class Subjectmarkservice
    {
        private readonly DatabaseContext _dbContext;
        public Subjectmarkservice(DatabaseContext dbContext)

        {
            this._dbContext = dbContext;

        }
        public async Task<List<SubjectViewModels>> GetStudent()
        {

            var items = await _dbContext.students.Select(s => new SubjectViewModels()
            {
               StudentsId = s.StudentId,
               Studentname = s.FirstName
            }).ToListAsync();
            return items;
        }
        public async Task<List<MSViewModels>> GetSubjects()
        {

            var items = await _dbContext.subjects.Select(s => new MSViewModels()
            {
               SubjectId = s.SubjectId,
               Subjectname = s.SubjectName
            }).ToListAsync();
            return items;
        }
    }
    public class SubjectViewModels
    {

        public Guid StudentsId { get; set; }
        public string Studentname { get; set; }
        //public List<MarkViewModels>? Mark { get; set; }

    }
    public class MSViewModels
    {

        public Guid SubjectId { get; set; }
        public string Subjectname { get; set; }
        
    }
    public class MarksssViewModels
    {
        public string Subjectname { get; set; }

    }
}
