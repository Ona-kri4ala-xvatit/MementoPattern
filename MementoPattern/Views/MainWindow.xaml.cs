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
        private int current_index = 0;

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
            if (index == current_index - 1)
            {
                return;
            }

            originator.SetMemento(caretaker.RestoreMemento(++index));

            textBoxName.Text = originator.User.Name;
            textBoxSurname.Text = originator.User.Surname;
            textBoxDescription.Text = originator.User.Description;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxSurname.Text) && string.IsNullOrEmpty(textBoxDescription.Text))
            {
                return;
            }
            originator.User.Name = textBoxName.Text;
            originator.User.Surname = textBoxSurname.Text;
            originator.User.Description = textBoxDescription.Text;

            memento = originator.CreateMemento();
            caretaker.SaveMemento(memento);

            current_index = ++index;

            textBoxName.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
        }

        private void buttonShowInfo_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(caretaker.ShowListElement(current_index, index), "Replace?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                caretaker.ReplaceElemenet(current_index, index);
            }
            else
            {
                return;
            }
        }
    }
}
