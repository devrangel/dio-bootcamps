namespace Domain.Entities
{
    class Costumer : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Costumer(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
