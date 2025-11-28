using ege_math_trainer.Models;

namespace ege_math_trainer
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PartOneTask> PartOneTasks { get; set; } = new();
        public List<PartTwoTask> PartTwoTasks { get; set; } = new();
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
