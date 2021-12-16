namespace Backend.Dtos
{
    public record GetEntityDto
    {
        public int id { get; init; }
        public string name { get; set; }
    }
}