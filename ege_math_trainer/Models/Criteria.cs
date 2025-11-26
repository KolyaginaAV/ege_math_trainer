namespace ege_math_trainer.Models
{
    public class Criteria
    {
        public int Id { get; set; }
        public string EvaluationCriteria { get; set; } //общие критерии для одного типа заданий (по умолчанию)
        public string ImageEvaluationCriteriaPath { get; set; }
    }
}
