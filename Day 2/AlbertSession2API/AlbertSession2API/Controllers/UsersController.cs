using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlbertSession2API.Models;

namespace AlbertSession2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AlbertTwoContext _context;

        public UsersController(AlbertTwoContext context)

        {
            _context = context;
        }

       
    }
}
