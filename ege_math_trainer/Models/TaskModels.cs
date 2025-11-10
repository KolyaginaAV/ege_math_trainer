namespace ege_math_trainer.Models
{
   public abstract class Task 
    {
        public int Id { get; set; }
        public string NameNumer { get; set; }
        public string Condition { get; set; }
        public string Decision { get; set; }
        public string? ImageDecisionPath { get; set; }
        public string? ImageConditionPath { get; set; }
    }
    public class PartOneTask: Task
    {
        public string RightAnswer { get; set; }
    }
    public class PartTwoTask: Task
    {
        public string EvaluationCriteria { get; set; }
    }
}
