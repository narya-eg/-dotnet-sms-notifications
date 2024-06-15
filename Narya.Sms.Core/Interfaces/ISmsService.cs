using Narya.Sms.Core.Models;

namespace Narya.Sms.Core.Interfaces;

public interface ISmsService
{
    Task Send(SmsModel options);
    Task Send(SmsModel options, dynamic configuration);
}