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
        public DbSet<Task> Tasks { get; set; }
        public DbSet<PartOneTask> PartOneTasks { get; set; }
        public DbSet<PartTwoTask> PartTwoTasks { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted(); //удаление БД
            Database.EnsureCreated(); //создание бд

            //прогрузили в бд данные мб надо закомментить
            Roles.Load();
            Users.Load();
            Criterias.Load();
            Tasks.Load();
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

            Task Task1 = new Task() { Id = 1, Name = "Задание 1: Планиметрия" };
            Task Task2 = new Task() { Id = 2, Name = "Задание 2: Векторы" };
            Task Task3 = new Task() { Id = 3, Name = "Задание 3: Стереометрия" };
            Task Task4 = new Task() { Id = 4, Name = "Задание 4: Начала теории вероятностей", };
            Task Task5 = new Task() { Id = 5, Name = "Задание 5: Вероятности сложных событий" };
            Task Task6 = new Task() { Id = 6, Name = "Задание 6: Простейшие уравнения" };
            Task Task7 = new Task() { Id = 7, Name = "Задание 7: Вычисления и преобразования" };
            Task Task8 = new Task() { Id = 8, Name = "Задание 8: Производная и первообразная" };
            Task Task9 = new Task() { Id = 9, Name = "Задание 9: Задачи с прикладным содержанием" };
            Task Task10 = new Task() { Id = 10, Name = "Задание 10: Текстовые задачи" };
            Task Task11 = new Task() { Id = 11, Name = "Задание 11: Графики функций" };
            Task Task12 = new Task() { Id = 12, Name = "Задание 12: Наибольшее и наименьшее значение функций", };
            Task Task13 = new Task() { Id = 13, Name = "Задание 13: Уравнения" };
            Task Task14 = new Task() { Id = 14, Name = "Задание 14: Стереометрическая задача" };
            Task Task15 = new Task() { Id = 15, Name = "Задание 15: Неравенства" };
            Task Task16 = new Task() { Id = 16, Name = "Задание 16: Финансовая математика", };
            Task Task17 = new Task() { Id = 17, Name = "Задание 17: Планиметрическая задача" };
            Task Task18 = new Task() { Id = 18, Name = "Задание 18: Задача с параметром" };
            Task Task19 = new Task() { Id = 19, Name = "Задание 19: Числа и их свойства" };

            //PartTwoTask partTwoTask13 = new PartTwoTask() { Id = 13, Condition = "", 
            //     ConditionImage = "", RightAnswer = "", Decision = "",
            //     DecisionImagePath = "",
            //    IndEvaluationCriteria = "", CriteriaId = criteria13.Id};
            // PartTwoTask partTwoTask14 = new PartTwoTask() { Id = 14, Condition = "", 
            //     ConditionImage = "", RightAnswer = "", Decision = "",
            //     DecisionImagePath = "",
            //     IndEvaluationCriteria = "", CriteriaId = criteria14.Id};
            // PartTwoTask partTwoTask15 = new PartTwoTask() { Id = 15, Condition = "", 
            //     ConditionImage = "", RightAnswer = "", Decision = "",
            //     DecisionImagePath = "",
            //     IndEvaluationCriteria = "", CriteriaId = criteria15.Id};
            // PartTwoTask partTwoTask16 = new PartTwoTask() { Id = 16, Condition = "", 
            //     ConditionImage = "", RightAnswer = "", Decision = "",
            //     DecisionImagePath = "", 
            //     IndEvaluationCriteria = "", CriteriaId = criteria16.Id};
            // PartTwoTask partTwoTask17 = new PartTwoTask() { Id = 17, Condition = "", 
            //     ConditionImage = "", RightAnswer = "", Decision = "",
            //     DecisionImagePath = "",                IndEvaluationCriteria = "", CriteriaId = criteria17.Id};
            // PartTwoTask partTwoTask18 = new PartTwoTask() { Id = 18, Condition = "", 
            //     ConditionImage = "", RightAnswer = "", Decision = "",
            //     DecisionImagePath = "", 
            //     IndEvaluationCriteria = "", CriteriaId = criteria18.Id};
            // PartTwoTask partTwoTask19 = new PartTwoTask() { Id = 19, Condition = "", 
            //     ConditionImage = "", RightAnswer = "", Decision = "",
            //     DecisionImagePath = "", 
            //     IndEvaluationCriteria = "", CriteriaId = criteria19.Id};

            PartOneTask partOneTask1 = new PartOneTask() { Id = 1, Condition = "В треугольнике ABC угол C равен 90°, AB=10, BC=√19. Найдите cosA.",
                ConditionImage = "ImagesCondition/partOneTask1condition.png", Decision = "Косинус это отношение прилежащего катета к гипотенузе. В данном случае cosA=AC/AB.\nНам неизвестно AC, находим его по обратной теореме Пифагора:\nAC=√AB²-BC²=√81=9.\nТеперь нам всё известно. Подставляем:\ncosA=9/10=0,9",
                RightAnswer = "0.9", TaskId = Task1.Id};
            PartOneTask partOneTask2 = new PartOneTask() { Id = 2, Condition = "Даны векторы a(25; 0) и b(1; −5). Найдите длину вектора a-4b.",
                Decision = "Для начала найдем значение вектора 4b, для этого каждую его кооринату умножим на 4. Получаем: (4*1;4*(−5))=(4;−20).\nДля того чтобы найти значение длины вектора a-4b найдем для начала его координаты:a-4b=(х2-х1;у2-у1)=(4-25;-20-0)=(-21;-20).\nДлина вектора a-4b равна:\n|a-4b|=√(-21)²+(-20)²=√441+400=√841=29.",
                RightAnswer = "29", TaskId = Task2.Id };
            PartOneTask partOneTask3 = new PartOneTask() { Id = 3, Condition = "Радиус основания цилиндра равен 2, высота равна 3. Найдите площадь боковой поверхности цилиндра, деленную на π.",
                ConditionImage = "ImagesCondition/partOneTask3condition.jpg", Decision = "Площадь боковой поверхности цилиндра вычисляется по формуле: Sбок = 2πRh, где R — радиус основания, h — высота цилиндра.\nДано: R=2, h=3\nПодставляем: Sбок =2π⋅2⋅3=12π\nТеперь делим на π:Sбок/π=12π/π=12",
                RightAnswer = "12", TaskId = Task3.Id};
            PartOneTask partOneTask4 = new PartOneTask() { Id = 4, Condition = "В сборнике билетов по географии всего 50 билетов, в пятнадцати из них встречается вопрос по теме «Страны Африки». Найдите вероятность того, что в случайно выбранном на экзамене билете школьнику достанется вопрос по теме «Страны Африки».",
                Decision = "Вероятность равна отношению числа благоприятных исходов к числу всех исходов.\nБлагоприятные исходы — те, в которых школьнику достанется вопрос по теме «Логарифмы». Число таких исходов равно 13.\nЧисло всех исходов равно общему количеству билетов, то есть 52.\nТогда вероятность того, что в случайно выбранном на экзамене билете школьнику достанется вопрос по теме «Логарифмы», равна:",
                DecisionImagePath = "ImagesDecision/partOneTask4decision.jpg", RightAnswer = "0.25", TaskId = Task4.Id };
            PartOneTask partOneTask5 = new PartOneTask() { Id = 5, Condition = "Перед началом футбольного матча судья бросает монетку, чтобы определить, какая из команд начнёт игру с мячом. Команда «Изумруд» играет два матча с разными командами. Найдите вероятность того, что в этих матчах команда «Изумруд» начнёт игру с мячом не больше одного раза.",
                Decision = "Рассмотрим все возможные исходы жеребьёвки для двух матчей. Каждый матч имеет два равновероятных исхода: команда «Изумруд» начинает игру — обозначим за 1 — или не начинает — обозначим за 0.\nПеречислим все возможные исходы: 00, 01, 10, 11. Значит, всевозможных исходов 4.\nБлагоприятные исходы это те, в которых команда «Изумруд» начнёт игру с мячом не более одного раза. Перечислим благоприятные исходы: 00, 10, 01. Значит, благоприятных исходов 3.\nВероятность равна отношению числа благоприятных исходов к числу всех исходов:",
                DecisionImagePath = "ImagesDecision/partOneTask5decision.jpg", RightAnswer = "0.75", TaskId = Task5.Id };
            PartOneTask partOneTask6 = new PartOneTask() { Id = 6, Condition = "Найдите корень уравнения", ConditionImage = "ImagesCondition/partOneTask6condition.jpg",
                Decision = "Перейдём от уравнения к системе и решим её:", DecisionImagePath = "ImagesDecision/partOneTask6decision.jpg", 
                RightAnswer = "1.4", TaskId = Task6.Id };
            PartOneTask partOneTask7 = new PartOneTask() { Id = 7, Condition = "Найдите значение выражения", ConditionImage = "ImagesCondition/partOneTask7condition.jpg",
                Decision = "Воспользуемся свойствами степеней и найдём значение выражения.", DecisionImagePath = "ImagesDecision/partOneTask7decision.jpg",
                RightAnswer = "4", TaskId = Task7.Id };
            PartOneTask partOneTask8 = new PartOneTask() { Id = 8, Condition = "На рисунке изображён график функции y = f(x), определённой на интервале (−1;10). Определите количество целых точек, в которых производная функции f(x) отрицательна.",
                ConditionImage = "ImagesCondition/partOneTask8condition.jpg", Decision = "В целых точках экстремума 0, 2, 5 производная равна нулю, тогда эти точки точно учитывать не будем.\nСреди других целых точек на интервале (−1;10) промежуткам убывания функции f(x) принадлежат точки 3, 4. \nТаким образом, производная функции y = f(x) отрицательна в двух целых точках.",
                RightAnswer = "2", TaskId = Task8.Id };
            PartOneTask partOneTask9 = new PartOneTask() { Id = 9, Condition = "В боковой стенке высокого цилиндрического бака у самого дна закреплён кран. После его открытия вода начинает вытекать из бака, при этом высота столба воды в нём меняется по закону H(t) =at²+ bt+H₀, где H   — высота столба воды в метрах, H₀ = 8 м — начальный уровень воды, a = 1/72 м/мин² и b = − 2/3 м/мин — постоянные, t — время в минутах, прошедшее с момента открытия крана. Сколько минут вода будет вытекать из бака?",
                Decision = "Задача сводится к решению квадратного уравнения с дробными коэффициентами.\nИз условия известно, что H — это высота столба воды в момент времени t.\nНам необходимо найти время t, при котором вся вода вытечет из бака, то есть высота столба воды H будет равна нулю. Тогда имеем уравнение, решив, которое получаем, что вода будет вытекать из бака в течение 24 минут.",
                DecisionImagePath = "ImagesDecision/partOneTask9decision.jpg", RightAnswer = "24", TaskId = Task9.Id };
            PartOneTask partOneTask10 = new PartOneTask() { Id = 10, Condition = "Из двух городов, расстояние между которыми равно 840 км, одновременно навстречу друг другу выехали два автомобилиста. Скорость первого 70 км/ч, а скорость второго 60 км/ч. Через сколько часов они встретились, если известно, что автомобиль первого автомобилиста сломался на полпути между этими городами и на его починку пришлось потратить час.",
                Decision = "Половина расстояния между городами 420 км. Это расстояние первый автомобилист преодолел за 6 часов, а второй автомобилист за 7 часов.\nТак как первый сломался на полпути между городами, то через 7 часов после начала движения он также был на полпути между городами, то есть, через 7 часов они встретились.",
                RightAnswer = "7", TaskId = Task10.Id };
            PartOneTask partOneTask11 = new PartOneTask() { Id = 11, Condition = "На рисунке изображён график функции вида f(x)= kx+ b. Найдите значение f(5).", ConditionImage = "ImagesCondition/partOneTask11condition.jpg",
                Decision = "Заметим, что первая прямая проходит через точки (0;1)   и (1;3). Если прямая проходит через точку на плоскости, то координаты этой точки обращают уравнение этой прямой в верное равенство. Тогда получаем систему из двух уравнений, решив которую узнаём, что b = 1, a k = 2. Зная это, составляем уравнение прямой и подставляем значения.",
                DecisionImagePath = "ImagesDecision/partOneTask11decision.jpg", RightAnswer = "11", TaskId = Task11.Id };
            PartOneTask partOneTask12 = new PartOneTask() { Id = 12, Condition = "Найдите точку минимума функции y = 2x−ln(x+ 11)+8.", Decision = "Обозначим f(x)=2x−ln(x+ 11)+8.\nНайдем производную функции:\nf′(x) = (2x− ln(x+ 11)+ 8)′ = (2x)′−(ln(x+ 11)′+(8)′ = 2-1/(x+11)+0 = 2-1/(x+11) = (2x+21)/(x+11)\nЛегко видеть, что полученная дробь зануляется при x=−21/2 и не определена при x=−11.\nПрименим метод интервалов для определения знаков производной. Обе критические точки встречаются в нечетном числе множителей, следовательно, знак в них будет меняться.\nВ точке минимума функции её производная обнуляется и меняет знак с «−» на «+», так как до точки минимума функция убывала, а после — начала возрастать. Значит, x =−10,5 — точка минимума функции y=2x−ln(x+11)+8.",
                DecisionImagePath = "ImagesDecision/partOneTask12decision.jpg", RightAnswer = "-10.5", TaskId = Task12.Id };

            //добавление в БД
            modelBuilder.Entity<Role>().HasData(teacher, student);
            modelBuilder.Entity<User>().HasData(techer1, student1);
            modelBuilder.Entity<Task>().HasData(Task1, Task2, Task3, Task4, Task5, Task6, Task7, Task8, Task9, Task10, Task11, Task12,
                Task13, Task14, Task15, Task16, Task17, Task18, Task19);
            modelBuilder.Entity<Criteria>().HasData(criteria13, criteria14, criteria15, criteria16, criteria17, criteria18, criteria19);
            modelBuilder.Entity<PartOneTask>().HasData(partOneTask1, partOneTask2, partOneTask3, partOneTask4, partOneTask5, partOneTask6,
            partOneTask7, partOneTask8, partOneTask9, partOneTask10, partOneTask11, partOneTask12);
            //modelBuilder.Entity<PartTwoTask>().HasData(partTwoTask13, partTwoTask14, partTwoTask15, partTwoTask16, partTwoTask17, partTwoTask18, partTwoTask19);

            //SaveChanges() - не надо, потому что этот метод вызывает в момент создания БД
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=databaseSQLite.db");
        }
    }
}
