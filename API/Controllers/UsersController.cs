using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("Api/[controller]")]//api/users
public class UsersController(DataContext context) : ControllerBase
{
    

    [HttpGet]
   public async Task<ActionResult<IEnumerable<AppUser>>>GetUsrs(){

   var users= await context.Users.ToListAsync();

   return users;

   }

     [HttpGet("{id:int}")]
   public async Task<ActionResult<AppUser>>GetUsr(int id){

   var user= await context.Users.FindAsync(id);

   if(user==null) return NotFound();

   return user;

   }
}

