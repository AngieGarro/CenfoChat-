using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : Controller
	{
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(Room rm)
		{
			try
			{
				var room = new RoomManager();
				room.CreateRoom(rm);
				return Ok(rm);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		[Route("Update")]
		public async Task<IActionResult> Update(Room rm)
		{
			try
			{
				var room = new RoomManager();
				room.UpdateRoom(rm);
				return Ok(rm);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> Delete(Room rm)
		{
			try
			{
				var room = new RoomManager();
				room.DeleteRoom(rm);
				return Ok(rm);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//Llamado de la Data.
		[HttpGet]
		[Route("RetrieveAll")]
		public async Task<IActionResult> RetrieveAll()
		{
			try
			{
				var room = new RoomManager();
				var LstRooms = room.RetrieveAll();
				return Ok(LstRooms);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//RetrieveAll Users.
		[HttpGet]
		[Route("RetrieveAllUsers")]
		public async Task<IActionResult> RetrieveAllUsers()
		{
			try
			{
				var usr = new RoomManager();
				var LstUsers = usr.GetToApi();
				return Ok(LstUsers);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("RetrieveById")]
		public async Task<IActionResult> RetrieveById(int Id)
		{
			try
			{
				var room = new RoomManager();
				room.RetrieveById<Room>(Id);
				return Ok(Id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
