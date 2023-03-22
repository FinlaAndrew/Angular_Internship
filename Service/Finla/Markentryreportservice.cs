using dotnetcoretraining.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Service.Finla
{
    public class Markentryreportservice
    {
        private readonly DatabaseContext _dbContext;
         public Markentryreportservice(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public async Task<List<stusubjectsViewModels>> getStusub()
        {

            var items = _dbContext.students.Select(s => new stusubjectsViewModels()
            {
                StudentId = s.StudentId,
                Studentname = s.FirstName
            }).ToList();
            return items;
        }
    }
    public class stusubjectsViewModels
    {
        public Guid StudentId { get; set; }
        public string Studentname { get; set; }
    }
    public class MarksViewModels
    {
        public string Studentname { get; set; }

    }
}
