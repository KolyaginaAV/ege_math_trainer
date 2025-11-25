namespace ege_math_trainer.Models
{
   public abstract class TaskModels 
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; } //условие
        public string? ConditionImage { get; set; }
        public string Decision { get; set; } //решение
        public string? DecisionImagePath { get; set; }
    }
}
