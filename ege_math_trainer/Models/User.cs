namespace ege_math_trainer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        /// <summary>
        /// По умолчанию ученик
        /// </summary>
        public string Role { get; set; } = "Ученик";

    }
}
