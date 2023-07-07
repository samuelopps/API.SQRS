using CQRS.API.Core.Notifications;

namespace CQRS.API.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            _notifications = new List<Notification>();
        }

        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }

        private List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void SetNotificationList(List<Notification> notifications)
        {
            _notifications = notifications;
        }

        public abstract bool Validate();
    }
}
