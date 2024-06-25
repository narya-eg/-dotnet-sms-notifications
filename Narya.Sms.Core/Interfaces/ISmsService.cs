using Narya.Sms.Core.Models;

namespace Narya.Sms.Core.Interfaces;

public interface ISmsService
{
    Task<Result> Send(Models.Sms options);
    Task<Result> Send(Models.Sms options, dynamic configuration);
}