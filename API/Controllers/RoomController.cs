using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Room.Requests;
using Application.Dtos.Room.Responses;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [Produces(typeof(GetRoomsResponse))]
        [Authorize(Roles = (Role.Landlord))]
        [HttpGet("{flatId}")]
        public async Task<IActionResult> GetRooms([FromRoute] int flatId)
        {
            var response = await _roomService.GetRoomsAsync(flatId);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest request)
        {
            var response = await _roomService.CreateRoomAsync(request);
            return SendResponse(response);
        }

        [Authorize(Roles = (Role.Landlord))]
        [HttpDelete("{flatId}/{roomId}")]
        public async Task<IActionResult> DeleteRoom([FromRoute] int flatId, [FromRoute] int roomId)
        {
            var response = await _roomService.DeleteRoomAsync(flatId, roomId);
            return SendResponse(response);
        }
    }
}
