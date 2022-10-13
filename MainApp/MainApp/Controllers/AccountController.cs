﻿using MainApp.Data;
using MainApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MainWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(IUserService userService, UserManager<IdentityUser> userManager, ApplicationDbContext dbcontext)
        {
            _userService = userService;
            _userManager = userManager;
            _dbcontext = dbcontext;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            try
            {
                var response = await _userService.Authenticate(user);
                if (response == null)
                    return Unauthorized(new { message = "Username or password is incorrect" });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var userName = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    return Ok(_dbcontext.Pasien.SingleOrDefault(x => x.UserId == user.Id));
                }
                throw new SystemException("Maaf Anda Tidak Memiliki Akses !");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("updatedevicetoken")]
        //public async Task<IActionResult> UpdateDeviceToken(string deviceToken)
        //{
        //    try
        //    {
        //        var userName = User.Identity.Name;
        //        var user = await _userManager.FindByNameAsync(userName);
        //        if (user != null)
        //        {
        //            var peserta = _dbcontext.Pasien.SingleOrDefault(x => x.UserId == user.Id);
        //            if(peserta!=null)
        //            {
        //               // peserta.DeviceToken = deviceToken;
        //                _dbcontext.SaveChanges();
        //                return Ok();
        //            }
        //        }
        //        throw new SystemException("Maaf Anda Tidak Memiliki Akses !");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}