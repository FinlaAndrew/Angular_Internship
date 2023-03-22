//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using dotnetcoretraining.Model;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Web.Models.JayarajCJ;

//namespace dotnetcoretraining.Controllers.Jayaraj
//{
   // [Route("country")]

    //public class CountryController : ControllerBase
   // {
       // private readonly DatabaseContext _dbContext;
       // public CountryController(DatabaseContext dbContext)
       // {
        //    this._dbContext = dbContext;
       // }
        //[HttpPost("savecontry")]
       // public async Task<IActionResult> Save([FromBody] CountryViewModel model)
       // {
         //   var saveData = new CountryJay()
        //    {
         //       Name = model.Name,
         //       SortOrder = model.SortOrder


          //  };
          //  await _dbContext.CountryJays.AddAsync(saveData);
          //  await _dbContext.SaveChangesAsync();
           // return Ok(saveData);



        //}

      //  [HttpGet("getData")]
       // public async Task<IActionResult> GetData()
       // {

         //   var items = await _dbContext.CountryJays.ToListAsync();

        //    return Ok(items);
        //}


       // [HttpDelete("deletecountry/{id}")]
       // public async Task<IActionResult> DeleteCountry(Guid id)
        //{


           // var country = await _dbContext.CountryJays
             //   .Where(s => s.Id == id)
            //    .SingleOrDefaultAsync();
           // _dbContext.CountryJays.Remove(country);
           // await _dbContext.SaveChangesAsync();
          //  return Ok(country);


        //}






      //  [HttpPatch("updatecountry/{id}")]
       // public async Task<IActionResult> UpdateCountry(Guid id, [FromBody] CountryViewModel model)
       // {
            //try
           // {

        //
               // var contry = _dbContext.CountryJays.Where(s => s.Id == id).FirstOrDefault();



               // if (contry != null)
               // {
                  //  contry.Name = model.Name;
                  //  contry.SortOrder = model.SortOrder;
            //
                //    await _dbContext.SaveChangesAsync();
                //    return Ok(contry);

               // }

               // else
              //  {
                 //   return NoContent();
               // }


           // }

           // catch (Exception)
            //{
                //throw;
            //}




       // }



        //[HttpGet("sortorder")]

        //public async Task<int> GetNewSortOrder()
       // {
            //var maxSort = _dbContext.CountryJays.Max(p => p.SortOrder);
            //int sortOrder = maxSort + 1;
           // return sortOrder;




        //}














    //}
    //public class CountryViewModel
    //{
       // public string Name { get; set; }
        //public int SortOrder { get; set; }



    //}



//}
