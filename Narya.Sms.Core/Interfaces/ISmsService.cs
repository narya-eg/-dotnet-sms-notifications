using Narya.Sms.Core.Models;

namespace Narya.Sms.Core.Interfaces;

public interface ISmsService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sms"></param>
    /// <returns></returns>
    Task Send(SmsModel sms);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sms"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    Task Send(SmsModel sms, dynamic configuration);
}