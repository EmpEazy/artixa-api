namespace Artixa.API.Models;

public class SendOtpRequest
{
    public string PhoneNumber { get; set; }
}

public class VerifyOtpRequest
{
    public string Pin { get; set; }
}