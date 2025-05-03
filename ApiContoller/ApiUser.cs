using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlLite_TEST.ApplicationController.Models;

namespace SqlLite_TEST.ApiContoller
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserApi : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User u = new($"id={id}");


            return u.Id != 0 ? Ok(u) : BadRequest("Nie ma takiego uzyt");

        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User u)
        {
            if (u == null)
            {
                return BadRequest("Niepoprawne user");
            }

            u.Create();

            return Ok(u);
        }
    }



}
