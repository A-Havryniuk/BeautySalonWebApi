namespace BeautySalon.Contracts.Dtos
{
    public class EmployeeDTO
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _position;
        private DateTime _birthday;
        private string _phone_number;
        private int _payment_percent;
        private string _email;

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
        public string Position
        { 
            get => _position; set => _position = value;
        }
        public DateTime Birthday
        {
            get => _birthday; set => _birthday = value;
        }
        public string PhoneNumber
        {
            get => _phone_number; set => _phone_number = value;
        }
        public int PaymentPercent
        {
            get => _payment_percent; set => _payment_percent = value;
        }
        public string Email
        {
            get => _email; set => _email = value;
        }
    }
}
