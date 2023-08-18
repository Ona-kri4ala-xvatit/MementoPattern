using System;

namespace MementoPattern.Models
{
    public class User : ICloneable
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public User(string name = null, string surname = null, string description = null)
        {
            Name = name ?? "Unknown";
            Surname = surname ?? "Unknown"; ;
            Description = description ?? "Unknown"; ;
        }
        public override string ToString()
        {
            return $"{Name} {Surname}\n{Description}";
        }

        public object Clone()
        {
            return (User)MemberwiseClone();
        }
    }
}
