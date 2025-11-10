using ege_math_trainer.Models;
namespace ege_math_trainer
{
    internal class AppContext
    {
        public static List<User> Users { get; set; } =
            new()
            {
                new User()
                {
                    Id = 1,
                    Login = "1",
                    Password = "1",
                    Surname = "Иванов",
                    Name = "Иван",
                    Patronymic = "Иванович",
                    Phone = "67987692",
                    Email = "IIIvanov@mail.ru"
                },
                new User()
                {
                    Id = 2,
                    Login = "2",
                    Password = "2",
                    Surname = "Петрова",
                    Name = "Мария",
                    Patronymic = "Иванович",
                    Phone = "497796",
                    Email = "PetrovaMI@mail.ru"
                }
            };
    }
}
