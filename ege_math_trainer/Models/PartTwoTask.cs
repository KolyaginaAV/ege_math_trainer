namespace ege_math_trainer.Models
{
    public class PartTwoTask : TaskModels
    {
        public string EvaluationCriteria { get; set; } //общие критерии для одного типа заданий (по умолчанию)
        public string ImageEvaluationCriteriaPath { get; set; }
        public string IndEvaluationCriteria { get; set; } //индивидуальные критерии для одного задания
    }
}
