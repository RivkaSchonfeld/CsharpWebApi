namespace school.Entity
{
    public class Client
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public Client(string id, string name, string address, string phone, DateTime dateOfBirth, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
    }
}
