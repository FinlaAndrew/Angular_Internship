using dotnetcoretraining.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Service.Finla
{
    public class Studentreportservice
    {
        private readonly DatabaseContext _dbContext;
        

        public Studentreportservice(DatabaseContext dbContext
            )
        {
            this._dbContext = dbContext;
            
        }
        public async Task<List<countrysViewModels>> getCountry()
        {

            var items = await _dbContext.countrys.Select(s => new countrysViewModels()
            {
                Id = s.Id,
                country = s.Name
            }).ToListAsync();
            return items;
        }
    }
    public class countrysViewModels
    {
        public Guid Id { get; set; }
        public string country { get; set; }
    }
    public class StudentsViewModels
    {
        public string Age { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; } 
       // public  string
        
        
    }
}
