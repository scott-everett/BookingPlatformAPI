using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookingPlatformAPI.Helpers;
using BookingPlatformAPI.Models;
using BookingPlatformAPI.Models.DataPayload;
using BookingPlatformAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingPlatformAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRoomBookingService _roomBookingService;
        private readonly IAccountService _accountService;

        public RoomBookingController(ILogger<RoomBookingController> logger, IRoomBookingService roomBookingService,
            IAccountService accountService)
        {
            _logger = logger;
            _roomBookingService = roomBookingService;
            _accountService = accountService;
        }

        // Get the bookings for the specified account id
        [HttpGet]
        public ActionResult<IEnumerable<RoomBooking>> GetRoomBookingsForAccount(long accountId)
        {
            try
            {
                // Check if the request is for the authorized accountId
                if (accountId != _accountService.GetAccountIdFromClaimsPrincipal(this.User))
                {
                    _logger.LogWarning("Unauthorized access attempt!  Attempt made to get room bookings for accountId {accountId} - different to the one that has been authenticated!", accountId);
                    return StatusCode((int)HttpStatusCode.Unauthorized);
                }

                var rooms = _roomBookingService.RoomBookingsForAccount(accountId).ToList();
                _logger.LogInformation("Room bookings for accountId {accountId} returned successfully.", accountId);

                return Ok(rooms);
            }
            catch(Exception e)
            {
                _logger.LogWarning(e, "Error obtaining bookings for accountId {accountId}!", accountId);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // Create a new booking
        [HttpPost]
        public ActionResult<string> CreateBooking(CreateBookingRequest request)
        {
            try
            {
                // Check if the request is for the authorized accountId
                if (request.AccountId != _accountService.GetAccountIdFromClaimsPrincipal(this.User))
                {
                    _logger.LogWarning("Unauthorized access attempt!  Attempt made to create a booking for accountId {accountId} - different to the one that has been authenticated!", request.AccountId);
                    return StatusCode((int)HttpStatusCode.Unauthorized);
                }

                _roomBookingService.CreateBooking(request);
                _logger.LogInformation("Booking for (accountId {accountId}, roomId {roomId}) created successfully.", request.AccountId, request.RoomId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Error creating booking for (accountId {accountId}, roomId {roomId})!", request.AccountId, request.RoomId);

                // Default status code
                int httpStatusCode = (int)HttpStatusCode.InternalServerError;

                if (e is NotFoundException || e is RoomCapacityInsufficentException || e is RoomNotAvailableException)
                {
                    httpStatusCode = (int)HttpStatusCode.UnprocessableEntity;
                }

                return StatusCode(httpStatusCode, e.GetType().Name);
            }
        }
    }
}
