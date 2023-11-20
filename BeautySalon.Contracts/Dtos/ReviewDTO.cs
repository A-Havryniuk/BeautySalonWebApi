namespace BeautySalon.Contracts.Dtos
{
    public class ReviewDTO
    {
        private int _id;
        private string _client_email;
        private string _employee_email;
        private string _text;
        private int _rate;

        public int Id { get =>  _id; 
            set => _id = value; 
        }
        public string ClientEmail
        {
            get => _client_email;
            set => _client_email = value; 
        }
        public string EmployeeEmail
        {
            get => _employee_email;
            set => _employee_email = value; 
        }
        public string Text
        {
            get => _text;
            set => _text = value;
        }
        public int Rate
        {
            get => _rate; set => _rate = value;
        }
    }
}
