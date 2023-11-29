namespace BeautySalon.Contracts.Dtos
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public int PaymentPercent { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
