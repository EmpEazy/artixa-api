using Artixa.API.Models;
using Artixa.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artixa.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private static string CurrentOtp = "";

        private readonly TwilioService _twilio;

        public AuthController(
            TwilioService twilio)
        {
            _twilio = twilio;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp(
            SendOtpRequest request)
        {
            string otp =
                new Random()
                    .Next(100000, 999999)
                    .ToString();

            CurrentOtp = otp;

            await _twilio.SendOtp(
                request.PhoneNumber,
                otp);

            return Ok(new
            {
                success = true
            });
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp(
            VerifyOtpRequest request)
        {
            if (request.Pin == CurrentOtp)
            {
                return Ok(new
                {
                    success = true
                });
            }

            return BadRequest(new
            {
                success = false
            });
        }
    }
}