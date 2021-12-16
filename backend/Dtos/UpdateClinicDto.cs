namespace Backend.Dtos
{
    public record UpdateClinicDto
    {
        public string name { get; set; }
        public string address { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string menager_id { get; set; }
        public int specialization_id { get; set; }
    }
}