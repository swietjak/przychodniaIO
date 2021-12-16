namespace Backend.Dtos
{
    public record UpdateMedicDto : CreateUserDto
    {
        public string role { get; set; }
        public int[] specialization_ids { get; set; }
        public int[] clinic_ids { get; set; }
    }
}