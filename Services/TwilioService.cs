using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Artixa.API.Services
{
    public class TwilioService
    {
        private readonly IConfiguration _config;

        public TwilioService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendOtp(string phone, string code)
        {
            string sid =
     Environment.GetEnvironmentVariable(
         "TWILIO_ACCOUNT_SID");

            string token =
                Environment.GetEnvironmentVariable(
                    "TWILIO_AUTH_TOKEN");

            string from =
                Environment.GetEnvironmentVariable(
                    "TWILIO_PHONE_NUMBER");

            TwilioClient.Init(sid, token);

            await MessageResource.CreateAsync(
                to: new PhoneNumber(phone),
                from: new PhoneNumber(from),
                body: $"Your Artixa verification code is {code}"
            );
        }
    }
}