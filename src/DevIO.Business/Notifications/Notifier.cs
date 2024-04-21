using DevIO.Business.Interfaces;

namespace DevIO.Business.Notifications;
public class Notifier : INotifier
{
    private List<Notification> _notifications;

    public Notifier()
    {
        _notifications = [];
    }

    public void Handle(Notification notification)
    {
        _notifications.Add(notification);
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public bool HasNotification()
    {
        return _notifications.Any();
    }
}
