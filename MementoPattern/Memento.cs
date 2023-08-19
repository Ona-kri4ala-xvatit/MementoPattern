using MementoPattern.Models;

namespace MementoPattern
{
    public class Memento
    {
        private readonly string name;
        private readonly string surname;
        private readonly string description;

        public Memento(User user)
        {
           name = user.Name;
           surname = user.Surname;
           description = user.Description;
        }

        public User Restore()
        {
            var user = new User
            {
                Name = name,
                Surname = surname,
                Description = description
            };
            return user;
        }
    }
}
