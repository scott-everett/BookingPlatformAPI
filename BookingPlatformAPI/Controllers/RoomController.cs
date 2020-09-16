using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookingPlatformAPI.Helpers;
using BookingPlatformAPI.Models;
using BookingPlatformAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingPlatformAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRoomService _roomService;

        public RoomController(ILogger<RoomController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            // Get the room data
            try
            {
                var rooms = _roomService.Rooms().ToList();
                _logger.LogInformation("Rooms list returned successfully");
                return Ok(rooms);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Error obtaining rooms list!");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
