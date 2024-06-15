using Microsoft.Extensions.Configuration;
using Narya.Sms.Core.Extensions;
using Narya.Sms.Core.Interfaces;
using Narya.Sms.Core.Models;
using Narya.Sms.Twilio.Extensions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Narya.Sms.Twilio.Services;

public class SmsService : ISmsService
{
    private TwilioConfig _twilioConfig;

    public SmsService(IConfiguration configuration)
    {
        _twilioConfig = configuration.GetTwilioConfig();
    }

    public async Task Send(SmsModel sms)
    {
        TwilioClient.Init(_twilioConfig.AccountSID, _twilioConfig.AuthToken);

        var messageResource = await MessageResource.CreateAsync(
            new PhoneNumber(sms.To),
            from: new PhoneNumber(_twilioConfig.From),
            body: sms.Message);
    }

    public async Task Send(SmsModel sms, dynamic configuration)
    {
        if (configuration is not object) throw new Exception("Twilio configuration is not a valid configurations.");
        _twilioConfig = ModelExtension.ConvertTo<TwilioConfig>(configuration);
        await Send(sms);
    }
}