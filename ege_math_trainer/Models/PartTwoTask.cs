namespace ege_math_trainer.Models
{
    public class PartTwoTask
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; } //условие
        public string? ConditionImage { get; set; }
        public string Decision { get; set; } //решение
        public string? DecisionImagePath { get; set; }
        public string IndEvaluationCriteria { get; set; } //индивидуальные критерии для каждого задания
        public Criteria Criteria { get; set; }
        public int CriteriaId { get; set; }
        public List<User> Users { get; set; } = new();
    }
}
