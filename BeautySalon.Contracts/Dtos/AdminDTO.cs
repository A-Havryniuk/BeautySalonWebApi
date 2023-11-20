namespace BeautySalon.Contracts.Dtos
{
    public class AdminDTO
    {
        private int _id;
        private string _email;
        private string _name;
        private string _surname;
        private string _phone;

        public int Id
        {
            get => _id; set => _id = value;
        }

        public string Email
        {
            get => _email; set => _email = value;
        }

        public string Name
        {
            get => _name; set => _name = value;
        }

        public string Surname
        {
            get => _surname; set => _surname = value;
        }

        public string Phone
        {
            get => _phone; set => _phone = value;
        }
    }
}
