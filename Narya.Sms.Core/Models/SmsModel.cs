namespace Narya.Sms.Core.Models;

public class SmsModel
{
    public SmsModel(string to, string message)
    {
        To = to;
        Message = message;
    }

    public string To { get; private set; } // Phone numbers comma seperated
    public string Message { get; private set; }
}