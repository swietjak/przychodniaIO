namespace Backend.Dtos
{
    public record CreateMedicDto : CreateUserDto
    {
        public string role { get; set; }
        public int[] specialization_ids { get; set; }
        public int[] clinic_ids { get; set; }
    }
}