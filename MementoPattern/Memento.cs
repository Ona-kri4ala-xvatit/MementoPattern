using MementoPattern.Models;

namespace MementoPattern
{
    public class Memento
    {
        public User User { get; private set; }

        public Memento(User user)
        {
            //User.Name = user.Name;
            //User.Surname = user.Surname;
            //User.Description = user.Description;
            User = user;    
        }
    }
}
