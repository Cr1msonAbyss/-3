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
    public delegate void TaskDelegate(string message);

    public class Task
    {
        public string Name { get; set; }
        public TaskDelegate Execute { get; set; }

        public Task(string name, TaskDelegate execute)
        {
            Name = name;
            Execute = execute;
        }

        public void Run()
        {
            if (Execute != null)
            {
                Execute($"Executing task: {Name}");
            }
            else
            {
                throw new InvalidOperationException("Не выбран делегат");
            }
        }
    }

    public partial class MainWindow : Window
    {
        private List<Task> tasks = new List<Task>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var description = TaskDescription.Text;
            if (string.IsNullOrWhiteSpace(description)) return;

            TaskDelegate selectedDelegate = null;
            var selectedItem = DelegateSelector.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                switch (selectedItem.Tag)
                {
                    case "Notify":
                        selectedDelegate = Notify;
                        break;
                    case "Log":
                        selectedDelegate = LogToFile;
                        break;
                }
            }

            if (selectedDelegate != null)
            {
                var task = new Task(description, selectedDelegate);
                tasks.Add(task);
                TaskList.Items.Add(task.Name);
                TaskDescription.Clear();
            }
            else
            {
                MessageBox.Show("Выберите делегат");
            }
        }

        private void ShowTaskInfo_Click(object sender, RoutedEventArgs e)
        {
            var selectedTaskName = TaskList.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(selectedTaskName))
            {
                MessageBox.Show("Выберете задачу из списка");
                return;
            }

            var task = tasks.FirstOrDefault(t => t.Name == selectedTaskName);
            if (task != null)
            {
                string delegateName = task.Execute != null ? task.Execute.Method.Name : "Не добавлен делегат";
                MessageBox.Show($"Задача: {task.Name}\nДелегат: {delegateName}");
            }
            else
            {
                MessageBox.Show("задача не найдена");
            }
        }

        private void Notify(string message)
        {
            MessageBox.Show(message);
        }

        private void LogToFile(string message)
        {
            MessageBox.Show(message);
        }
    }
}
