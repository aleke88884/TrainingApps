using AlbertSessionSecondApi.DTO;
using AlbertSessionSecondApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlbertSessionSecondApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly AlbertSessionSecondContext _context;

        public OfferController(AlbertSessionSecondContext context)
        {
            _context = context;
        }


        [HttpGet("getOffer/{userId}")]
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetOffersByUserId(int userId)
        {
            var offers = await _context.Offers.Where(o => o.UserId == userId)
                .Include("Request")
                .Include("Reservations")
                .Include("User")
                .OrderBy(a => a.Request != null ? a.Request.Name : "")
                .Select(f => new OfferDto { 
                    offerId = f.OfferId,
                    Amount = f.Request!= null ? f.Request.Amount : 0,
                    userId = f.UserId ?? 0,
                    requestId = f.RequestId,
                    requestedItemName = f.Request != null ? f.Request.Name : "",
                    reservations = f.Reservations.Select(r => new ReservationDTO
                    {
                        reservationId = r.ReservationId,
                        startTime = r.StartTime,
                        endTime = r.EndTime,
                        reservedByUsername = r.ReservedByUser != null ? r.ReservedByUser.Username : "Unknown User",
                    }).ToList(),

                }).ToListAsync();

            return offers;
        }


        
    }
}
