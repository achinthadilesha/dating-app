using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{   
    public class UsersController : BaseApiController
    {
        public DataContext Context { get; }
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }


        //! return a list of users
        //! /api/users/
        [AllowAnonymous]
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {

            var users = await  _context.Users.ToListAsync();

            return users;
        }

        //! return a single user from Id
        //! /api/users/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) 
        {

            var user = await _context.Users.FindAsync(id);

            return user;
        }

    }
}