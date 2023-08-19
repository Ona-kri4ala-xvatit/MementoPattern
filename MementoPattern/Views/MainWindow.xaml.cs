using MementoPattern.Models;
using System.IO;
using System.Windows;

namespace MementoPattern
{
    public partial class MainWindow : Window
    {
        private readonly Originator originator = new Originator();
        private readonly Caretaker caretaker;
        private Memento? memento;

        private int index = 0;

        public MainWindow()
        {
            InitializeComponent();
            originator.User = new User();
            caretaker = new Caretaker();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            if (index == 0)
            {
                return;
            }

            originator.SetMemento(caretaker.RestoreMemento(--index));

            textBoxName.Text = originator.User.Name;
            textBoxSurname.Text = originator.User.Surname;
            textBoxDescription.Text = originator.User.Description;
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            originator.User.Name = textBoxName.Text;
            originator.User.Surname = textBoxSurname.Text;
            originator.User.Description = textBoxDescription.Text;

            memento = originator.CreateMemento();
            caretaker.SaveMemento(memento);

            index++;

            textBoxName.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
        }
    }
}
