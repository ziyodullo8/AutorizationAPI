using AutorizationAPI.Data;
using AutorizationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutorizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TodoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            var todo=await _dataContext.Todo.ToListAsync();
            return Ok(todo);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            await _dataContext.Todo.AddAsync(todo);
            await _dataContext.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpDelete]
        public  async Task<IActionResult> Delete(int id)
        {
          var todo= await _dataContext.Todo.FirstOrDefaultAsync(t=>t.id==id);
            if (todo!=null)
            {
                _dataContext.Todo.Remove(todo);
                _dataContext.SaveChanges();

            }
            return Ok(todo);
        }
    }
}
