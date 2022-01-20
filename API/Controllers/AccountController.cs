using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        public readonly DataContext _context;
        public ITokenService _tokenService { get; }

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdto)
        {


            if (await UserExists(registerdto.Username))
            {
                return BadRequest("Username is already in use !");
            }

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerdto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto{
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto logindto)
        {
            // get user from data-base
            var user = await _context.Users
            .SingleOrDefaultAsync(x => x.UserName == logindto.Username);

            if(user == null){
                return Unauthorized("Invalid Username");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));

            for(int i=0; i<computedHash.Length; i++){
                if(computedHash[i] != user.PasswordHash[i]){
                    return Unauthorized("Invalid Password");
                }
            }

            return new UserDto{
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
            };

        }


        //? checking if usernamealredy exists
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}