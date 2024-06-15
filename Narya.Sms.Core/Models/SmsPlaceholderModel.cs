namespace Narya.Sms.Core.Models;

public sealed class SmsPlaceholderModel
{
    private SmsPlaceholderModel()
    {
    }

    public SmsPlaceholderModel(string placeholder, string value)
    {
        Placeholder = placeholder;
        Value = value;
    }

    public string Placeholder { get; private set; }
    public string Value { get; private set; }
}