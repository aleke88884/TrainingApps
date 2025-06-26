using AESessionFourApi.Helpers;
using AESessionFourApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AESessionFour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AlbertFourContext context;

        public HomeController(AlbertFourContext context)
        {
            this.context = context;
        }


        [HttpPost("addTicket")]
        public async Task<ActionResult<TicketDto>> AddTicket([FromBody] AddTicketRequest request)
        {
            var ticket = new Ticket
            {
                TicketNr = request.TicketNr,
                EventId = request.EventId,
                UserId = request.UserId,
                TotalPrice = request.TotalPrice,
                Persons = request.Persons
            };

            context.Tickets.Add(ticket);
            await context.SaveChangesAsync(); // не забудь сохранить

            return Ok(ticket);
        }













        [HttpGet("getEvents")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents(
            [FromQuery] string? name,
            [FromQuery] string? location,
            [FromQuery] DateTime? start
            
            )
        {

            var query = context.Events.Include("Pictures")
                .Include("ProgramPoints")
                .Include("Tickets").AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            // Фильтрация по Location
            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(e => e.Location.Contains(location));
            }

      
            if (start.HasValue)
            {
                var date = start.Value.Date;
                query = query.Where(e => e.Start.Date == date);
            }
            var events = await query
         .Select(e => new EventDto
         {
             EventId = e.EventId,
             Name = e.Name,
             Location = e.Location,
             Start = e.Start,
             End = e.End,
             Price = e.Price,
             Pictures = e.Pictures.Select(f => new PictureDto
             {
                 PictureId = f.PictureId,
                 Picture1 = f.Picture1,
                 EventId = f.EventId,
             }).ToList(),
             ProgramPoints = e.ProgramPoints.Select(a => new ProgramPointDto
             {
                 ProgramPointId = a.ProgramPointId,
                 EventId = a.EventId,
                 Name = a.Name,
                 Order = a.Order,
             }).ToList(),
             Tickets = e.Tickets.Select(d => new TicketDto
             {
                 TicketNr = d.TicketNr,
                 EventId = d.EventId,
                 UserId = d.UserId,
                 TotalPrice = d.TotalPrice,
                 Persons = d.Persons,
             }).ToList(),
         })
         .ToListAsync();

            return Ok(events);
        }












        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if(string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.password))
            {
                return BadRequest(new LoginResponseDto
                {
                    message = "Username and password cannot be empty",
                    success = false,

                });
            }
            var user = context.Users.FirstOrDefault(u => u.Username == request.username);
            if(user == null)
            {
                return NotFound(new LoginResponseDto { 
                    message = "Username or password incorrect",
                    success = false,
                
                });
            }
            if(user.Password == request.password)
            {
                return Ok(new LoginResponseDto
                {
                    success = true,
                    message = "Login succesfull"
                });
            }
            else
            {
                return Unauthorized(new LoginResponseDto
                {
                    message = "invalid password",
                    success = false,
                });
            }
        }



    }



}
