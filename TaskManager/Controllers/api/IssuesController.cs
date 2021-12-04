using TaskManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private AppDbContext _context;
        public IssuesController(AppDbContext db)
        {
            _context = db;
        }

        //Get the list of tasks api/Issues/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> Get()
        {
            return await _context.Issues.Include(t=> t.IssueType).Include(s=> s.IssueStatus).ToListAsync();
        }

        // GET the task by id api/issues/id

        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> Get(int id)
        {
            Issue issue = _context.Issues.FirstOrDefault(x => x.Id == id);
            if (issue == null)
            {
                return NotFound();
            }
            return new ObjectResult(issue);
        }

        // POST api/Issues
        [HttpPost]
        public async Task<ActionResult<Issue>> Post(Issue issue)
        {
            if (issue == null)
            {
                return BadRequest();
            }
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return Ok(issue);
        }

        // PUT api/Issues
        [HttpPut]
        public async Task<ActionResult<Issue>> Put(Issue issue)
        {
            if (issue == null)
            {
                return BadRequest();
            }
            if (!_context.Issues.Any(x => x.Id == issue.Id))
            {
                return NotFound();
            }
            _context.Issues.Update(issue);
            await _context.SaveChangesAsync();
            return Ok(issue);
        }


        //DELETE api/Issues/id

        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> Delete(int id)
        {
            Issue issue = await _context.Issues.FirstOrDefaultAsync(x => x.Id == id);
            if (issue == null)
            {
                return NotFound();
            }
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return Ok(issue);
        }
    }
}
