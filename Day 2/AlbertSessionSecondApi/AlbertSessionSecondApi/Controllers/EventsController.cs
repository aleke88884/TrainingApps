using AlbertSessionSecondApi.DTO;
using AlbertSessionSecondApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlbertSessionSecondApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AlbertSessionSecondContext _context;
        public EventsController(AlbertSessionSecondContext context) {
            _context = context;
        }


        [HttpGet("getEvents/{userId}")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsByUserId(int userId)
        {
            var now = DateTime.Now;


            var events = await _context.Events
                .Where(e => e.UserId == userId )
                .Include("Location")
                .Include("RequestedItems")
                .Include("User")
                .OrderBy(e => e.Start)
                .Select(e => new EventDto { 
                    eventId = e.EventId,
                    userId = e.UserId,
                    locationId = e.LocationId,
                    name = e.Name,
                    start = e.Start,
                    end = e.End,
                    locationName = e.Location.Name,
                    requestedItems = e.RequestedItems.Select(r => new RequestedItemDto { 
                        RequestedItemId = r.RequestedItemId,
                        Name = r.Name,
                        EventId = r.EventId,
                        Amount = r.Amount,
                        IsFull = r.Reservations.Any(),

                    }).ToList()
                }).ToListAsync();

            return Ok(events);
        }

        
    }
}
