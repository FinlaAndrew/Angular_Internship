using dotnetcoretraining.Model;
using dotnetcoretraining.Service.Finla;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Controllers
{
    [Route("sub")]
    public class allstudentscontroller : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly allstudentsservice _service;

        public allstudentscontroller(DatabaseContext dbContext, allstudentsservice service)
        {
            this._dbContext = dbContext;
            this._service = service;
        }
        [HttpGet("subview")]
        public async Task<IActionResult> getallsub()
        {
            var items = await _service.getallsub();

            return Ok(items);
        }
    }
        
}
