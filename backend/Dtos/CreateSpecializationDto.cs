namespace Backend.Dtos
{
    public record CreateSpecializationDto
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
