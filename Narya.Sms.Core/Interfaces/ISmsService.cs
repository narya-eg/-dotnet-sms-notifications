using Narya.Sms.Core.Models;

namespace Narya.Sms.Core.Interfaces;

public interface ISmsService
{
    Task<Result> Send(SmsModel options);
    Task<Result> Send(SmsModel options, dynamic configuration);
}