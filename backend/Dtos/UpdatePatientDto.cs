namespace Backend.Dtos
{
    public record UpdatePatientDto : CreateUserDto
    {
        public string insuranceId { get; set; }
    }
}