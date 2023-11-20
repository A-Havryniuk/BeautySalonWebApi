namespace BeautySalon.Contracts.Dtos
{
    public class ServiceDTO
    {
        private int _id;
        private string _name;
        private int _duration;
        private int _price;

        public int Id
        {
            get => _id; set => _id = value;
        }

        public string Name
        {
            get => _name; set => _name = value;
        }

        public int Duration
        {
            get => _duration; set => _duration = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }
    }
}
