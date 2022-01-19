using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //api controller
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public DataContext Context { get; }
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }


        //! return a list of users
        //! /api/users/
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {

            var users = await  _context.Users.ToListAsync();

            return users;
        }

        //! return a single user from Id
        //! /api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) 
        {

            var user = await _context.Users.FindAsync(id);

            return user;
        }

    }
}