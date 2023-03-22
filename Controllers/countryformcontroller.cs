using dotnetcoretraining.Model;
using dotnetcoretraining.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Controllers
{
    [Route("country")]
    public class countryformcontroller : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public countryformcontroller(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost("savecountry")]
        public async Task<IActionResult> Save([FromBody] CountryViewModels model)
        {
            var saveData = new country()
            {
                Name = model.Name,
                SortOrder = model.SortOrder
            };
            await _dbContext.countrys.AddAsync(saveData);
            await _dbContext.SaveChangesAsync();
            return Ok(saveData);
        }
        [HttpGet("getData")]
        public async Task<IActionResult> GetData()
        {

            var items = await _dbContext.countrys.ToListAsync();

            return Ok(items);
        }
        [HttpDelete("deletecountry/{id}")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            var country = await _dbContext.countrys.Where(s => s.Id == id).SingleOrDefaultAsync();
            //Where(s => s.StudentId == Guid.Parse(id)).FirstOrDefault();
            _dbContext.countrys.Remove(country);
            await _dbContext.SaveChangesAsync();
            return Ok(country);
        }

        [HttpGet("geteditdata/{id}")]

        public async Task<IActionResult> GeteditCountry(Guid id)
        {
            var country = await _dbContext.countrys.Where(s => s.Id == id).Select(s => new CountryViewModels()
            {
                Name = s.Name,
                SortOrder = s.SortOrder
            }).ToListAsync();
            return Ok(country);
        }
        [HttpPatch("updatecountry/{id}")]
        public async Task<IActionResult> UpdateCountry(Guid id, [FromBody] CountryViewModels model)
        {
            var country = _dbContext.countrys.Where(s => s.Id == id).FirstOrDefault();
            country.Name = model.Name;
            country.SortOrder = model.SortOrder;

            _dbContext.countrys.Update(country);
            await _dbContext.SaveChangesAsync();
            return Ok(country);
        }
        [HttpGet("sortorder")]

        public async Task<int> SortOrder()
        {
            var maxSort = _dbContext.countrys.Max(p => p.SortOrder);
            int sortOrder = maxSort + 1;

           // await _dbContext.SaveChangesAsync();
            return sortOrder;
        }
    }
        public class CountryViewModels
        {
            public string Name { get; set; }
            public int SortOrder { get; set; }
        }

    
}
