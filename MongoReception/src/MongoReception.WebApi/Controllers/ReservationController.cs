using Microsoft.AspNetCore.Mvc;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Entities;
using MongoReception.WebApi.Helpers;
using System;
using System.Threading.Tasks;

namespace MongoReception.WebApi.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet(ApiRoutes.Reservation.Specific)]
        public async Task<IActionResult> Get([FromRoute] string reservationId)
        {
            try
            {
                var requestedReservation = await _reservationService.GetReservation(reservationId);

                return Ok(requestedReservation);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete(ApiRoutes.Reservation.Specific)]
        public async Task<IActionResult> Delete([FromRoute] string reservationId)
        {
            try
            {
                await _reservationService.DeleteReservation(reservationId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut(ApiRoutes.Reservation.Specific)]
        public async Task<IActionResult> Update([FromRoute] Reservation reservation)
        {
            try
            {
                await _reservationService.UpdateReservation(reservation);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet(ApiRoutes.Reservation.Main)]
        public async Task<IActionResult> List()
        {
            try
            {
                var requestedReservations = await _reservationService.GetAllReservations();

                return Ok(requestedReservations);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Reservation.Main)]
        public async Task<IActionResult> Add([FromBody] Reservation reservation)
        {
            try
            {
                await _reservationService.AddReservation(reservation);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Reservation.Payment)]
        public async Task<IActionResult> AttachExtras([FromRoute] string reservationId)
        {
            try
            {
                await _reservationService.PayForReservation(reservationId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}