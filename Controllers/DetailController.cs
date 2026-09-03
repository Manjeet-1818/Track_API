using BuildAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly Student25Context std;
        public DetailController(Student25Context std) 
        {
            this.std = std;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Detail>>> GetStudent()
        {

            var data = await std.Details.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<List<Detail>>> AddStudent(Detail dt)
        {
            await std.Details.AddAsync(dt);
            await std.SaveChangesAsync();
            return Ok(dt);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Detail>>> UpdateStudent(int id,Detail detail)
        {
           if(id != detail.Id)
            {
                return BadRequest();
            }
            std.Entry(detail).State = EntityState.Modified;
            await std.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Detail>>> Delete(int id)
        {
            var st = await std.Details.FindAsync(id);
            if(st==null)
            {
                return NotFound();
            }
            std.Details.Remove(st);
            await std.SaveChangesAsync();
            return Ok();
        }
    }
}
