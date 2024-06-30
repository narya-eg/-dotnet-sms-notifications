using Narya.Sms.Core.Extensions;

namespace Narya.Sms.Core.Models;

public class Sms
{
    private Sms() { }
    private Sms(ICollection<string> to, string message)
    {
        To = to;
        Message = message;
    }

    public ICollection<string> To { get; private set; } = new List<string>();
    public string Message { get; private set; }

    public static Result<Sms> Create(string message, params string[] to)
    {
        foreach (var number in to)
        {
            if (number.IsValidPhoneNumber() is false)
                return Result<Sms>.Failure($"Invalid Phone Number {number}.");
        }
        Sms sms = new Sms(to, message);
        return Result<Sms>.Success(sms);
    }

}