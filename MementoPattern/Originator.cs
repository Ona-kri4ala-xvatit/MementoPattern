using MementoPattern.Models;

namespace MementoPattern
{
    public class Originator
    {
        public User User { get; set; }


        public Memento CreateMemento()
        {
            return new Memento(User);
        }

        public void SetMemento(Memento memento)
        {
            User = memento.Restore();
        }


    }
}
