using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class NotificationEventArgs : EventArgs
    {
        public string Message { get; }

        public NotificationEventArgs(string message)
        {
            Message = message;
        }
    }

    public class Notification
    {
        public event EventHandler<NotificationEventArgs> MessageSent;
        public event EventHandler<NotificationEventArgs> CallMade;
        public event EventHandler<NotificationEventArgs> EmailSent;

        public void SendMessage(string message)
        {
            OnMessageSent(new NotificationEventArgs(message));
        }

        public void MakeCall(string message)
        {
            OnCallMade(new NotificationEventArgs(message));
        }

        public void SendEmail(string message)
        {
            OnEmailSent(new NotificationEventArgs(message));
        }

        protected virtual void OnMessageSent(NotificationEventArgs e)
        {
            MessageSent?.Invoke(this, e);
        }

        protected virtual void OnCallMade(NotificationEventArgs e)
        {
            CallMade?.Invoke(this, e);
        }

        protected virtual void OnEmailSent(NotificationEventArgs e)
        {
            EmailSent?.Invoke(this, e);
        }
    }
}
