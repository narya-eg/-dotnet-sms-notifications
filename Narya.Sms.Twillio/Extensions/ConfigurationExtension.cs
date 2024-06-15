using Microsoft.Extensions.Configuration;
using Narya.Sms.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Narya.Sms.Twilio.Extensions;

public static class ConfigurationExtension
{
    public static TwilioConfig GetTwilioConfig(this IConfiguration configuration)
    {
        var config = configuration.GetSection("Twilio").Get<TwilioConfig>();
        if (config == null)
            throw new Exception("Missing 'Twilio' configuration section from the appsettings.");
        return config;
    }
}

public sealed class TwilioConfig : IProviderConfig
{
    [Required] public string? AccountSID { get; set; }
    [Required] public string? AuthToken { get; set; }
    [Required] public string? PathServiceSid { get; set; }
    [Required] public string? From { get; set; }

    public bool ValidateProperty(object instance, string propertyName, object? value)
    {
        return Validator.TryValidateProperty(value, new ValidationContext(instance) { MemberName = propertyName },
            new List<ValidationResult>());
    }
}