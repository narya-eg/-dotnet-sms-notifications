using Microsoft.Extensions.Configuration;
using Narya.Sms.Core.Models;
using Narya.Sms.Twilio.Extensions;
using Narya.Sms.Core.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Narya.Sms.Core.Extensions;

namespace Narya.Sms.Twilio.Services;

public class SmsService : ISmsService
{
    private readonly IConfiguration _configuration;
    private TwilioConfig _twilioConfig = new();

    public SmsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task Send(SmsModel options)
    {
        _twilioConfig = _configuration.GetTwilioConfig();
        await SendSms(options);
    }

    public async Task Send(SmsModel options, dynamic configuration)
    {
        if (configuration is not object) throw new Exception("Twilio configuration is not a valid configurations.");
        _twilioConfig = ModelExtension.ConvertTo<TwilioConfig>(configuration);
        await SendSms(options);
    }

    private async Task SendSms(SmsModel options)
    {
        TwilioClient.Init(_twilioConfig.AccountSID, _twilioConfig.AuthToken);

        var messageResource = await MessageResource.CreateAsync(
            new PhoneNumber(options.To),
            from: new PhoneNumber(_twilioConfig.From),
            body: options.Message);
    }
}