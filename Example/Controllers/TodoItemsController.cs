using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.Model;
using Example.Business;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Example.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class TodoItemsController : Controller
    {
        private readonly ITodoItemManager _manager;

        public TodoItemsController(ITodoItemManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await this._manager.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            if (Id == Guid.Empty)
                return Content("Id is null.");
            var result = await this._manager.GetByIdAsync(Id);
            if (result == null)
                return Content("User not found.");

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TodoItem item)
        {
            if (item == null)
                return Content("Payload is null.");

            var result = await this._manager.CreateAsync(item);
            return Ok(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TodoItem item)
        {
            if (id == Guid.Empty)
                return Content("Id is null.");

            var result = await this._manager.UpdateAsync(id, item);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (Id == Guid.Empty)
                return Content("Id is null.");
            var result = await this._manager.DeleteAsync(Id);
            if (result)
                return Content("User has been deleted.");

            return Ok(result);
        }
    }
}

