namespace server.Dto
{
    public class Test3Dto
    {

        public int Id { get; set; }
        public int courierId { get; set; }
        public string FIO { get; set; } = string.Empty;
        public string telephone { get; set; } = string.Empty;
        public int carId { get; set; }
        public DateTime date_time_order { get; set; } = DateTime.MinValue;
        public DateTime date_time_delivery { get; set; } = DateTime.MinValue;
        public DateTime date_time_delivery_actual { get; set; } = DateTime.MinValue;
        public int order_number { get; set; }
        public string status { get; set; } = string.Empty;
        public int typeId { get; set; }

    }
}

