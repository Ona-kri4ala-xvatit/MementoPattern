using System.Collections.Generic;
using System.Linq;

namespace MementoPattern
{
    public class Caretaker
    {
        private List<Memento> MementoList { get; set; }

        public Caretaker() 
        {
            MementoList = new List<Memento>();
        }

        public void SaveMemento(Memento memento)
        {
            MementoList.Add(memento);
        }

        public Memento RestoreMemento(int index)
        {
            return MementoList[index];
        }
    }
}
