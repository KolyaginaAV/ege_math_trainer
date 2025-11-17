namespace ege_math_trainer.Models
{
   public abstract class Task 
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; } //условие
        public string? ImageConditionPath { get; set; }
        public string Decision { get; set; } //решение
        public string? ImageDecisionPath { get; set; }
    }
    public class PartOneTask: Task
    {
        public string RightAnswer { get; set; }
    }
    public class PartTwoTask: Task
    {
        public string EvaluationCriteria { get; set; }
        public string ImageEvaluationCriteriaPath { get; set; }
        public string IndEvaluationCriteria { get; set; }
        public string ImageIndEvaluationCriteriaPath { get;set; }
    }
}
