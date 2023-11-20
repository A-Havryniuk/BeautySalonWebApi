namespace BeautySalon.Contracts.Dtos
{
    public class ClientDTO
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _phone_number;
        private string _email;
        private string _address;

        public int Id
        {
            get => _id; set => _id = value;
        }

        public string Name
        {
            get => _name; set => _name = value;
        }

        public string Surname
        {
            get => _surname; set => _surname = value;
        }

        public string PhoneNumber
        {
            get => _phone_number; set => _phone_number = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Address
        {
            get => _address; 
            set => _address = value; 
        }
    }

}
