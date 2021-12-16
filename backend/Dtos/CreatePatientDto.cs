namespace Backend.Dtos
{
    public record CreatePatientDto : CreateUserDto
    {
        public string insuranceId { get; set; }
    }
}