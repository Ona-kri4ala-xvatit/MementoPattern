using System;
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
            return MementoList.ElementAt(index);
        }

        public string ShowListElement(int current, int index)
        {
            if (MementoList.Count == 0 || current == index)
            {
                return string.Empty;
            }

            int last_element_index = current - 1;

            return $"Element to replace : {MementoList.ElementAt(last_element_index)}\n\nReplace this: {MementoList.ElementAt(index)}";
        }

        public void ReplaceElemenet(int current, int index)
        {
            int last_element_index = current - 1;
            MementoList[index] = MementoList[last_element_index];
        }
    }
}
