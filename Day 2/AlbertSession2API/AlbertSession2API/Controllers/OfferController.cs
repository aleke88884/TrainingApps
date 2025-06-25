using AlbertSession2API.DTO;
using AlbertSession2API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Composition.Convention;

namespace AlbertSession2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly AlbertTwoContext _context;


        public OfferController(AlbertTwoContext context)
        {
            _context = context;
        }

        [HttpGet("offer/{userId}")]
        public async Task<ActionResult<IEnumerable<OfferDTO>>> GetOffersByUserId(int userId)
        {
            var offers = await _context.Offers.Where(o => o.UserId == userId)
                .Include("Request")
                .Include("Reservations")
                .Include("User")
                .OrderBy(o => o.Request != null ? o.Request.Name : "")
                .Select(a => new OfferDTO {
                    offerId = a.OfferId,
                    userId = a.UserId,
                    requestId = a.RequestId,
                    requestedItemName = a.Request != null ? a.Request.Name : "Unnamed Offer",
                    reservations = a.Reservations.Select(r => new ReservationDTO {
                        reservationId = r.ReservationId,
                        startTime = r.StartTime,
                        endTime = r.EndTime,
                        reservedByUserName = r.ReservedByUser != null ? r.ReservedByUser.Username : "Unknown User",
                    }).ToList(),

                }).ToListAsync();

            return Ok(offers);
        }


      
      
    }
}
