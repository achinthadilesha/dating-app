using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {

            var users = _context.Users.ToList();

            return users;
        }

        //! return a single user from Id
        //! /api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {

            var user = _context.Users.Find(id);

            return user;
        }

    }
}