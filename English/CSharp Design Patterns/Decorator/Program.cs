// Base component
public interface INotification
{
    void SendMessage(string message);
}

// Concrete component
public class EmailNotification : INotification
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

// Base decorator
public abstract class NotificationDecorator : INotification
{
    protected INotification _notification;

    public NotificationDecorator(INotification notification)
    {
        _notification = notification;
    }

    public virtual void SendMessage(string message)
    {
        _notification.SendMessage(message);
    }
}

// Concrete decorator for SMS
public class SMSNotificationDecorator : NotificationDecorator
{
    public SMSNotificationDecorator(INotification notification) : base(notification) { }

    public override void SendMessage(string message)
    {
        base.SendMessage(message);
        Console.WriteLine($"Sending SMS: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Send notification via email
        INotification emailNotification = new EmailNotification();
        emailNotification.SendMessage("Hello!");

        // Send notification via email and SMS
        INotification smsAndEmailNotification = new SMSNotificationDecorator(emailNotification);
        smsAndEmailNotification.SendMessage("Hello!");
    }
}