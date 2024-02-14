using Core;
using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(User user)
        {
            var um = new UserManager();
            um.Create(user);
            return Ok(user);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(User user)
        {
            try
            {
                var usr = new UserManager();
                usr.UpdateUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(User user)
        {
            try
            {
                var usr = new UserManager();
                usr.DeleteUser(user);
                return Ok(user);
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
                var usr = new UserManager();
                var LstUsers = usr.RetrieveAll();
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
                var usr = new UserManager();
                usr.RetrieveById<User>(Id);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
