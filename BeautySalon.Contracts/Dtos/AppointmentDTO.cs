namespace BeautySalon.Contracts.Dtos
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public string ClientEmail { get; set; }

        public string EmployeeEmail { get; set; }

        public string ServiceName { get; set; }

        public DateTime DateTime { get; set; }

        public string Status { get; set; }
    }
}
