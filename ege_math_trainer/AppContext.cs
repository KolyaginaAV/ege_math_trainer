using System.Xml.Linq;
using ege_math_trainer.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ege_math_trainer
{
    public class AppContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<PartOneTask> PartOneTasks { get; set; }
        public DbSet<PartTwoTask> PartTwoTasks { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted(); //удаление БД
            Database.EnsureCreated(); //создание бд

            //прогрузили в бд данные
            Roles.Load();
            Users.Load();
            Criterias.Load();
            PartOneTasks.Load();
            PartTwoTasks.Load();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role teacher = new Role() { Id = 1, Name = "Teacher" };
            Role student = new Role() { Id = 2, Name = "Student" };

            User techer1 = new User() { Id = 1, Login = "ZakharovaAD", Password = "1234567Z", Surname = "Захарова", Name = "Алиса", 
                Patronymic = "Дмитриевна", Phone = "89247365970", Email = "ZakharovaAD@mail.ru", RoleId = teacher.Id };
            User student1 = new User() { Id = 2, Login = "KolesnikovIV", Password = "0987654K", Surname = "Колесников", Name = "Игорь", 
                Patronymic = "Викторович", Phone = "89247365970", Email = "KolesnikovIV@mail.ru", RoleId = student.Id };

            //добавление ролей и пользователей в БД
            modelBuilder.Entity<Role>().HasData(teacher, student);
            modelBuilder.Entity<User>().HasData(techer1, student1);
            //SaveChanges() - не надо, потому что этот метод вызывает в момент создания БД

            Criteria criteria13 = new Criteria() { Id = 13, EvaluationCriteria = "Задание 13 посвящено решению уравнений или неравенств, чаще всего тригонометрических. Оно проверяет умение работать с тригонометрическими формулами, проводить преобразования и находить все решения на заданном промежутке.",
                ImageEvaluationCriteriaPath = "ImagesCriteria/criteria13.png"};
            Criteria criteria14 = new Criteria() { Id = 14, EvaluationCriteria = "Задание 14 посвящено геометрии и проверяет умение решать стереометрические задачи. Абитуриенту необходимо не только знать теоремы и формулы, но и уметь применять их для нахождения длин, углов, площадей и объёмов.", 
                ImageEvaluationCriteriaPath = "ImagesCriteria/criteria14.png" };
            Criteria criteria15 = new Criteria() { Id = 15, EvaluationCriteria = "Задание 15 посвящено решению сложных уравнений и неравенств, включая показательные, логарифмические и иррациональные. Оно проверяет умение работать с преобразованиями, применять свойства функций и анализировать область допустимых значений.\r\n", 
                ImageEvaluationCriteriaPath = "ImagesCriteria/criteria15.png" };
            Criteria criteria16 = new Criteria() { Id = 16, EvaluationCriteria = "Задание 16 проверяет умение решать задачи на проценты, вклады, кредиты и другие экономические расчёты. Оно требует понимания финансовых операций и базовых математических моделей, таких как сложные проценты, аннуитеты и графики платежей.", 
                ImageEvaluationCriteriaPath = "ImagesCriteria/criteria16.png" };
            Criteria criteria17 = new Criteria() { Id = 17, EvaluationCriteria = "Задание 17 на ЕГЭ по профильной математике связано с решением задач на геометрическую интерпретацию и использование свойств фигур в планиметрии. Оно проверяет способность применять геометрические теоремы и формулы для решения задач, связанных с анализом объектов на плоскости.", 
                ImageEvaluationCriteriaPath = "ImagesCriteria/criteria17.png" };
            Criteria criteria18 = new Criteria() { Id = 18, EvaluationCriteria = "Задание 18 посвящено задачам с параметрами. Оно требует умения исследовать уравнения, неравенства или системы в зависимости от значения параметра. Это одно из самых сложных заданий ЕГЭ, так как требует аналитического мышления и навыков работы с графиками и функциями.", 
                ImageEvaluationCriteriaPath = "ImagesCriteria/criteria18.png" };
            Criteria criteria19 = new Criteria() { Id = 19, EvaluationCriteria = "Задание 19 связано с теорией чисел и проверяет навыки работы с делимостью, остатками, уравнениями в целых числах и другими свойствами чисел. Это задание требует глубокого понимания арифметики и логического мышления.", 
                ImageEvaluationCriteriaPath = "ImagesCriteria/criteria19.png" };

           //PartTwoTask partTwoTask13 = new PartTwoTask() { Id = 13, Number = 13, Name = "Задание 13: Уравнения", Condition = "", 
           //     ConditionImage = "", RightAnswer = "", Decision = "",
           //     DecisionImagePath = "",
           //    IndEvaluationCriteria = "", CriteriaId = criteria13.Id};
           // PartTwoTask partTwoTask14 = new PartTwoTask() { Id = 14, Number = 14, Name = "Задание 14: Стереометрическая задача", Condition = "", 
           //     ConditionImage = "", RightAnswer = "", Decision = "",
           //     DecisionImagePath = "",
           //     IndEvaluationCriteria = "", CriteriaId = criteria14.Id};
           // PartTwoTask partTwoTask15 = new PartTwoTask() { Id = 15, Number = 15, Name = "Задание 15: Неравенства", Condition = "", 
           //     ConditionImage = "", RightAnswer = "", Decision = "",
           //     DecisionImagePath = "",
           //     IndEvaluationCriteria = "", CriteriaId = criteria15.Id};
           // PartTwoTask partTwoTask16 = new PartTwoTask() { Id = 16, Number = 16, Name = "Задание 16: Финансовая математика", Condition = "", 
           //     ConditionImage = "", RightAnswer = "", Decision = "",
           //     DecisionImagePath = "", 
           //     IndEvaluationCriteria = "", CriteriaId = criteria16.Id};
           // PartTwoTask partTwoTask17 = new PartTwoTask() { Id = 17, Number = 17, Name = "Задание 17: Планиметрическая задача", Condition = "", 
           //     ConditionImage = "", RightAnswer = "", Decision = "",
           //     DecisionImagePath = "",                IndEvaluationCriteria = "", CriteriaId = criteria17.Id};
           // PartTwoTask partTwoTask18 = new PartTwoTask() { Id = 18, Number = 18, Name = "Задание 18: Задача с параметром", Condition = "", 
           //     ConditionImage = "", RightAnswer = "", Decision = "",
           //     DecisionImagePath = "", 
           //     IndEvaluationCriteria = "", CriteriaId = criteria18.Id};
           // PartTwoTask partTwoTask19 = new PartTwoTask() { Id = 19, Number = 19, Name = "Задание 19: Числа и их свойства", Condition = "", 
           //     ConditionImage = "", RightAnswer = "", Decision = "",
           //     DecisionImagePath = "", 
           //     IndEvaluationCriteria = "", CriteriaId = criteria19.Id};

            //PartOneTask partOneTask1 = new PartOneTask() { Id = 1, Number = 1, Name = "Задание 1: Планиметрия", Condition = "В треугольнике ABC угол C равен 90°, AB=10, BC=√19. Найдите cosA.", 
            //    ConditionImage = "ImagesCondition/partOneTask1condition.png", Decision = "Косинус это отношение прилежащего катета к гипотенузе. В данном случае cosA=AC/AB.\nНам неизвестно AC, находим его по обратной теореме Пифагора:\nAC=√AB²-BC²=√81=9.\nТеперь нам всё известно. Подставляем:\ncosA=9/10=0,9",
            //    RightAnswer = "0.9"};
            //PartOneTask partOneTask2 = new PartOneTask() { Id = 2, Number = 2, Name = "Задание 2: Векторы", Condition = "Даны векторы a(25; 0) и b(1; −5). Найдите длину вектора a-4b.", 
            //    Decision = "Для начала найдем значение вектора 4b, для этого каждую его кооринату умножим на 4. Получаем: (4*1;4*(−5))=(4;−20).\nДля того чтобы найти значение длины вектора a-4b найдем для начала его координаты:a-4b=(х2-х1;у2-у1)=(4-25;-20-0)=(-21;-20).\nДлина вектора a-4b равна:\n|a-4b|=√(-21)²+(-20)²=√441+400=√841=29.",
            //    RightAnswer = "29"};
            //PartOneTask partOneTask3 = new PartOneTask() { Id = 3, Number = 3, Name = "Задание 3: Стереометрия", Condition = "Радиус основания цилиндра равен 2, высота равна 3. Найдите площадь боковой поверхности цилиндра, деленную на π.", 
            //    ConditionImage = "ImagesCondition/partOneTask3condition.jpg", Decision = "Площадь боковой поверхности цилиндра вычисляется по формуле: Sбок = 2πRh, где R — радиус основания, h — высота цилиндра.\nДано: R=2, h=3\nПодставляем: Sбок =2π⋅2⋅3=12π\nТеперь делим на π:Sбок/π=12π/π=12",
            //    RightAnswer = "12"};
            //PartOneTask partOneTask4 = new PartOneTask() { Id = 4, Number = 4, Name = "Задание 4: Начала теории вероятностей", Condition = "В сборнике билетов по географии всего 50 билетов, в пятнадцати из них встречается вопрос по теме «Страны Африки». Найдите вероятность того, что в случайно выбранном на экзамене билете школьнику достанется вопрос по теме «Страны Африки».", 
            //    Decision = "Вероятность равна отношению числа благоприятных исходов к числу всех исходов.\nБлагоприятные исходы — те, в которых школьнику достанется вопрос по теме «Логарифмы». Число таких исходов равно 13.\nЧисло всех исходов равно общему количеству билетов, то есть 52.\nТогда вероятность того, что в случайно выбранном на экзамене билете школьнику достанется вопрос по теме «Логарифмы», равна:",
            //    DecisionImagePath = "ImagesDecision/partOneTask4decision.jpg", RightAnswer = "0.25"};
            //PartOneTask partOneTask5 = new PartOneTask() { Id = 5, Number = 5, Name = "Задание 5: Вероятности сложных событий", Condition = "Перед началом футбольного матча судья бросает монетку, чтобы определить, какая из команд начнёт игру с мячом. Команда «Изумруд» играет два матча с разными командами. Найдите вероятность того, что в этих матчах команда «Изумруд» начнёт игру с мячом не больше одного раза.", 
            //    Decision = "Рассмотрим все возможные исходы жеребьёвки для двух матчей. Каждый матч имеет два равновероятных исхода: команда «Изумруд» начинает игру — обозначим за 1 — или не начинает — обозначим за 0.\nПеречислим все возможные исходы: 00, 01, 10, 11. Значит, всевозможных исходов 4.\nБлагоприятные исходы это те, в которых команда «Изумруд» начнёт игру с мячом не более одного раза. Перечислим благоприятные исходы: 00, 10, 01. Значит, благоприятных исходов 3.\nВероятность равна отношению числа благоприятных исходов к числу всех исходов:",
            //    DecisionImagePath = "ImagesDecision/partOneTask5decision.jpg", RightAnswer = "0.75"};
            //PartOneTask partOneTask6 = new PartOneTask() { Id = 6, Number = 6, Name = "Задание 6: Простейшие уравнения", Condition = "Найдите корень уравнения", 
            //    ConditionImage = "ImagesCondition/partOneTask6condition.jpg", Decision = "Перейдём от уравнения к системе и решим её:",
            //    DecisionImagePath = "ImagesDecision/partOneTask6decision.jpg", RightAnswer = "1.4"};
            //PartOneTask partOneTask7 = new PartOneTask() { Id = 7, Number = 7, Name = "Задание 7: Вычисления и преобразования", Condition = "Найдите значение выражения", 
            //    ConditionImage = "ImagesCondition/partOneTask7condition.jpg", Decision = "Воспользуемся свойствами степеней и найдём значение выраженияЖ",
            //    DecisionImagePath = "ImagesDecision/partOneTask7decision.jpg", RightAnswer = "4"};
            //PartOneTask partOneTask8 = new PartOneTask() { Id = 8, Number = 8, Name = "Задание 8: Производная и первообразная", Condition = "На рисунке изображён график функции y = f(x),   определённой на интервале (−1;10). Определите количество целых точек, в которых производная функции f(x) отрицательна.", 
            //    ConditionImage = "ImagesCondition/partOneTask8condition.jpg", Decision = "В целых точках экстремума 0, 2, 5 производная равна нулю, тогда эти точки точно учитывать не будем.\nСреди других целых точек на интервале (−1;10) промежуткам убывания функции f(x) принадлежат точки 3, 4. \nТаким образом, производная функции y = f(x) отрицательна в двух целых точках.",
            //    RightAnswer = "2"};
            //PartOneTask partOneTask9 = new PartOneTask() { Id = 9, Number = 9, Name = "Задание 9: Задачи с прикладным содержанием", Condition = "В боковой стенке высокого цилиндрического бака у самого дна закреплён кран. После его открытия вода начинает вытекать из бака, при этом высота столба воды в нём меняется по закону H(t) =at²+ bt+H₀, где H   — высота столба воды в метрах, H₀ = 8 м — начальный уровень воды, a = 1/72 м/мин² и b = − 2/3 м/мин — постоянные, t — время в минутах, прошедшее с момента открытия крана. Сколько минут вода будет вытекать из бака?", 
            //    Decision = "Задача сводится к решению квадратного уравнения с дробными коэффициентами.\nИз условия известно, что H — это высота столба воды в момент времени t.\nНам необходимо найти время t, при котором вся вода вытечет из бака, то есть высота столба воды H будет равна нулю. Тогда имеем уравнение, решив, которое получаем, что вода будет вытекать из бака в течение 24 минут.",
            //    DecisionImagePath = "ImagesDecision/partOneTask9decision.jpg", RightAnswer = "24"};
            //PartOneTask partOneTask10 = new PartOneTask() { Id = 10, Number = 10, Name = "Задание 10: Текстовые задачи", Condition = "Из двух городов, расстояние между которыми равно 840 км, одновременно навстречу друг другу выехали два автомобилиста. Скорость первого 70 км/ч, а скорость второго 60 км/ч. Через сколько часов они встретились, если известно, что автомобиль первого автомобилиста сломался на полпути между этими городами и на его починку пришлось потратить час.", 
            //    Decision = "Половина расстояния между городами 420 км. Это расстояние первый автомобилист преодолел за 6 часов, а второй автомобилист за 7 часов.\nТак как первый сломался на полпути между городами, то через 7 часов после начала движения он также был на полпути между городами, то есть, через 7 часов они встретились.",
            //    RightAnswer = "7"};
            //PartOneTask partOneTask11 = new PartOneTask() { Id = 11, Number = 11, Name = "Задание 11: Графики функций", Condition = "На рисунке изображён график функции вида f(x)= kx+ b. Найдите значение f(5).", 
            //    ConditionImage = "ImagesCondition/partOneTask11condition.jpg", Decision = "Заметим, что первая прямая проходит через точки (0;1)   и (1;3).   Если прямая проходит через точку на плоскости, то координаты этой точки обращают уравнение этой прямой в верное равенство. Тогда получаем систему из двух уравнений, решив которую узнаём, что b = 1, a k = 2. Зная это, составляем уравнение прямой и подставляем значения.",
            //    DecisionImagePath = "ImagesDecision/partOneTask11decision.jpg", RightAnswer = "11"};
            //PartOneTask partOneTask12 = new PartOneTask() { Id = 12, Number = 12, Name = "Задание 12: Наибольшее и наименьшее значение функций", Condition = "Найдите точку минимума функции y = 2x−ln(x+ 11)+8.", 
            //    Decision = "Обозначим f(x)=2x−ln(x+ 11)+8.\nНайдем производную функции:\nf′(x) = (2x− ln(x+ 11)+ 8)′ = (2x)′−(ln(x+ 11)′+(8)′ = 2-1/(x+11)+0 = 2-1/(x+11) = (2x+21)/(x+11)\nЛегко видеть, что полученная дробь зануляется при x=−21/2 и не определена при x=−11.\nПрименим метод интервалов для определения знаков производной. Обе критические точки встречаются в нечетном числе множителей, следовательно, знак в них будет меняться.\nВ точке минимума функции её производная обнуляется и меняет знак с «−» на «+», так как до точки минимума функция убывала, а после — начала возрастать. Значит, x =−10,5 — точка минимума функции y=2x−ln(x+11)+8.",
            //    DecisionImagePath = "ImagesDecision/partOneTask12decision.jpg", RightAnswer = "-10.5"};

            modelBuilder.Entity<Criteria>().HasData(teacher, student);
            //modelBuilder.Entity<PartOneTask>().HasData(techer1, student1);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=databaseSQLite.db");
        }
    }
}
