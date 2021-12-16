namespace Backend.Dtos
{
    public record GetClinicDto
    {
        public int id { get; init; }
        public string name { get; set; }
        public string address { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string menager_id { get; set; }
        public GetSpecializationDto specialization { get; set; }
    }
}