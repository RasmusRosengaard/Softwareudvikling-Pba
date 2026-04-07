// Follows OCP
public interface INotification
{   
    void Send();
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        // Code to send email notification
    }
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        // Code to send SMS notification
    }
}
// Muligt at tilføje flere notifkationstyper uden at ændre eksisterende kode, hvilket overholder Open/Closed-princippet.

// Does not follow OCP
public class Notification
{
    public void SendEmail(string message)
    {
        // Code to send email notification
    }

    public void SendSms(string message)
    {
        // Code to send SMS notification
    }
}