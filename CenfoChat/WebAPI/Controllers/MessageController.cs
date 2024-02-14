using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> SendMessage(Message Msj)
		{
			try
			{
				var Sms = new MessageManager();
				Sms.SendMessage(Msj);
				return Ok(Msj);

			}catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		[Route("Update")]
		public async Task<IActionResult> Update(Message Msj)
		{
			try
			{
				var Sms = new MessageManager();
				Sms.UpdateMessage(Msj);
				return Ok(Msj);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> Delete(Message Msj)
		{
			try
			{
				var Sms = new MessageManager();
				Sms.DeleteMessage(Msj);
				return Ok(Msj);
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
				var Sms = new MessageManager();
				var LstMessages = Sms.RetrieveAll();
				return Ok(LstMessages);
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
				var sms = new MessageManager();
				sms.RetrieveById<Message>(Id);
				return Ok(Id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}

}

