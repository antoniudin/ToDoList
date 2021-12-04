using TaskManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<IdentityUser> _userManager;
        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // Determines whether the password combination is valid for the user

        [HttpGet("{id}/{password}")]
        public async Task<ActionResult<IdentityUser>> Get(string id, string password)
        {
            var user = await _userManager.FindByNameAsync(id);
            var result = await _userManager.CheckPasswordAsync(user, password);
            if (user == null)
            {
                return NotFound();
            }
                return Ok(result);
        }

        
    }
}
