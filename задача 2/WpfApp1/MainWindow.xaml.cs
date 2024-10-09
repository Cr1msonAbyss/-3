using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Notification notification = new Notification();
        public MainWindow()
        {
            InitializeComponent();
           
            notification.MessageSent += Notification_MessageSent;
            notification.CallMade += Notification_CallMade;
            notification.EmailSent += Notification_EmailSent;
        }

        private void Notification_MessageSent(object sender, NotificationEventArgs e)
        {
            MessageBox.Show($"Сообщение отправлено: {e.Message}");
        }

        private void Notification_CallMade(object sender, NotificationEventArgs e)
        {
            MessageBox.Show($"Звонок сделан: {e.Message}");
        }

        private void Notification_EmailSent(object sender, NotificationEventArgs e)
        {
            MessageBox.Show($"Email отправлен: {e.Message}");
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
           notification.SendMessage("Привет! Это тестовое сообщение.");
        }

        private void MakeCallButton_Click(object sender, RoutedEventArgs e)
        {
            notification.MakeCall("Звонок на номер 123-456-7890.");
        }

        private void SendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            notification.SendEmail("test@example.com");
        }
    }
}

