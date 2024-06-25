using Narya.Sms.Core.Extensions;

namespace Narya.Sms.Core.Models;

public class SmsModel
{
    private SmsModel(string to, string message)
    {
        To = to;
        Message = message;
    }

    public string To { get; private set; } // Phone numbers comma seperated
    public string Message { get; private set; }

    public static Result<SmsModel> Create(string to, string message)
    {
        if (to.IsValidPhoneNumber() is false)
            return Result<SmsModel>.Failure("Invalid Phone Number.");
        return Result<SmsModel>.Success(new SmsModel(to, message));
    }
}