using AlbertSessionSecondApi.DTO;
using AlbertSessionSecondApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlbertSessionSecondApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly AlbertSessionSecondContext _context;
        public RequestController(AlbertSessionSecondContext context)
        {
            _context = context;
        }

        [HttpGet("getRequests")]
        public async Task<ActionResult<IEnumerable<RequestedItemDto>>> GetRequests()
        {
            var requests = await _context.RequestedItems
                .Include("Offers")
                .Include("Reservations")
                .Include("Event")
                .OrderBy(r => r.Name)
                .Select(req => new RequestedItemDto
                {
                    RequestedItemId = req.RequestedItemId,
                    EventId = req.EventId,
                    Name = req.Name,
                    EventName = req.Event.Name,
                    Amount = req.Amount,
                    IsFull = req.Amount <= req.Reservations.Count, // Assuming IsFull means no more reservations can be made
                    ReservationCount = req.Reservations.Count,
                    Reservations = req.Reservations.Select(r => new ReservationDTO
                    {
                        reservationId = r.ReservationId,
                        startTime = r.StartTime,
                        endTime = r.EndTime,
                        reservedByUsername = r.ReservedByUser != null ? r.ReservedByUser.Username : "Unknown User"
                    }).ToList(),
                }).ToListAsync();
                
            if (requests == null || !requests.Any())
            {
                return NotFound("No requests found.");
            }
            return Ok(requests);
        }
    }
}
