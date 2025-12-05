namespace Notifications.Api.Services;

public class EmailSender
{
    public Task SendAsync(string to, string subject, string body)
    {
        // Integrar com SendGrid/SMTP no futuro. Aqui apenas log/console.
        Console.WriteLine($"Email => {to} | {subject} | {body}");
        return Task.CompletedTask;
    }
}

public class PushSender
{
    public Task SendAsync(string channel, string title, string body)
    {
        Console.WriteLine($"Push => {channel} | {title} | {body}");
        return Task.CompletedTask;
    }
}
