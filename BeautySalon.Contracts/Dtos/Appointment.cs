namespace BeautySalon.Contracts.Dtos
{
    public class Appointment
    {
        private int _id;
        private string _client_email;
        private string _employee_email;
        private string _service_name;
        private DateTime _date_time;
        private string _status;

        public int Id
        {
            get => _id; set => _id = value;
        }

        public string ClientEmail
        {
            get => _client_email;
            set => _client_email = value;
        }

        public string EmployeeEmail
        {
            get => _employee_email; set => _employee_email = value;
        }

        public string ServiceName
        {
            get => _service_name; set => _service_name = value;
        }

        public DateTime DateTime
        {
            get => _date_time; set => _date_time = value;
        }

        public string Status
        {
            get => _status; set => _status = value;
        }
    }
}
